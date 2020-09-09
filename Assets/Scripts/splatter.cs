using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class splatter : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxScale, minScale;
    public float minAspectRatio, maxAspectRatio;
    public Sprite src;
    public Texture dst;

    void Start()
    {

    }

    void BlitDrop(Sprite src, Texture dst)
    {
	// Select a random scale for this drop
	float scaleX = minScale + 
		(Random.value * (maxScale - minScale));

	float aspectRatio = minAspectRatio + 
		(Random.value * (maxAspectRatio - minAspectRatio));

	float scaleY = scaleX * aspectRatio;

	// Calculate the destination rect for this drop
	Rect dstRect = new Rect()
	{
		width = src.textureRect.width * scaleX,
		height = src.textureRect.height * scaleY
	};

	dstRect.x = random.Next(0, dst.width - (int) dstRect.width);
	dstRect.y = random.Next(0, dst.width - (int) dstRect.height);

	// Copy pixels from the drop (src) to the stain (dst)
	for (int y = 0; y < dstRect.height; ++y)
	{
		for (int x = 0; x < dstRect.width; ++x)
		{
			// Since the source drop is scaled, we bilinearly sample the 4 pixels 
			// around the exact location we want to sample
			Color srcColor = SampleBilinear(src.texture, 
				srcRect.x + x / scaleX, srcRect.y + y / scaleY);

			Color dstColor = dst.GetPixel((int)dstRect.x + x, (int) dstRect.y + y);
			
			// Write the new pixel value to the stain texture by taking
			// the maximum of the previous value and the new value
			dstColor = new Color(0, 0, 0, Math.Max(srcColor.a, dstColor.a));

			dst.SetPixel((int)dstRect.x + x, (int)dstRect.y + y, dstColor);
		}
	}
}


    // Update is called once per frame
    void Update()
    {
        
    }
}
