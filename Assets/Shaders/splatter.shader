Shader "Unlit/splatter"
{
Properties {
        _Color ("Main Color", Color) = (1,1,1,0.5)
        _MainTex ("Texture", 2D) = "white" { }
    }
    SubShader {
        Pass {

        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag

        #include "UnityCG.cginc"

        
        float _Smoothing;
        sampler2D _MainTex;
        fixed4 _Color;
        float4 _MainTex_ST;

        struct v2f {
            float4 pos : SV_POSITION;
            float2 uv : TEXCOORD0;
            fixed4 color: _Color;
        };

        v2f vert (appdata_base v)
        {
            v2f o;
            o.pos = UnityObjectToClipPos(v.vertex);
            o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);
            return o;
        }

        fixed4 frag (v2f i) : SV_Target
        {
            fixed4 texcol = tex2D (_MainTex, i.uv);
            return texcol * _Color;
            // Sample the distance value from the texture
            // A value of 0.5 means that the pixel is exactly on the shape edge
            fixed4 sdf = tex2D(_MainTex, i.uv);

            // Use our smoothing value to determine an alpha value for this pixel 
            fixed alpha = smoothstep(0.5 - _Smoothing, 0.5 + _Smoothing, sdf.a);

            // Combine the alpha with the vertex color to calculate the pixel color
            fixed4 c;
            c.rgb = i.color.rgb;
            c.a = i.color.a * alpha;

            return c;
        }
        ENDCG

        }
    }
}

