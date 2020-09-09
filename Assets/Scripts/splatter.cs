using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;


public class splatter : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxScale, minScale;
    public Sprite src;
    public Texture2D dst;
    private float aspectRatio;
    private Rect dstRect;
    private Color[] mapSrcPixels;
    private Color[] mapDstPixels;

    void Start()
    {
        aspectRatio = Camera.main.aspect;
        Debug.Log(aspectRatio);
        BlitDrop();
    }

    void BlitDrop()
    {
	// Select a random scale for this drop
    src.texture.filterMode = FilterMode.Bilinear;
    mapSrcPixels = src.texture.GetPixels(0,0,(int)src.rect.width,(int)src.rect.height);
    foreach (var item in mapSrcPixels)
    {
        Debug.Log(item);
    }

	// float scaleX = minScale + 
	// 	(Random.value * (maxScale - minScale));

	// aspectRatio = aspectRatio * Random.value;

	// float scaleY = scaleX * aspectRatio;

	// // Calculate the destination rect for this drop
	// dstRect = new Rect()
	// {
	// 	width = src.bounds.size.x * scaleX,
	// 	height = src.bounds.size.y * scaleY
	// };

	// dstRect.x = Random.value * (dst.width - (int) dstRect.width);
	// dstRect.y = Random.value * (dst.width - (int) dstRect.height);

	// // Copy pixels from the drop (src) to the stain (dst)
	// for (int y = 0; y < dstRect.height; ++y)
	// {
	// 	for (int x = 0; x < dstRect.width; ++x)
	// 	{
	// 		// Since the source drop is scaled, we bilinearly sample the 4 pixels 
	// 		// around the exact location we want to sample
	// 		mapSrcPixels[x + y] = (int)src.texture.GetPixel(x, y);

	// 		mapDstPixels = dst.GetPixel(x, y);
			
	// 		// Write the new pixel value to the stain texture by taking
	// 		// the maximum of the previous value and the new value
	// 		dstColor = new Color(0, 0, 0, Math.Max(srcColor.a, dstColor.a));

	// 		dst.SetPixel((int)dstRect.x + x, (int)dstRect.y + y, dstColor);
	// 	}
	// }
}


    // Update is called once per frame
    void Update()
    {
        
    }
}
