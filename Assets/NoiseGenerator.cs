using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGenerator : MonoBehaviour
{
    [SerializeField] private int height = 512;
    [SerializeField] private int width = 512;
    [SerializeField] private float xOrigin;
    [SerializeField] private float yOrigin;
    [SerializeField] private float scale = 10f;

    private Texture2D noiseTexture;
    private Renderer rend;
    private Color[] pix;
    
    // Start is called before the first frame update
    private void Start()
    {
        rend = GetComponent<Renderer>();
        noiseTexture = new Texture2D(width, height);
        pix = new Color[noiseTexture.width * noiseTexture.height];
        rend.material.mainTexture = noiseTexture;
    }
    
    private void Update()
    {
        CalculateNoise();
    }

    private void CalculateNoise()
    {
        var y = 0f;
        while (y < noiseTexture.height)
        {
            var x = 0f;
            while (x < noiseTexture.width)
            {
                var xCoord = xOrigin + x / noiseTexture.width * scale;
                var yCoord = yOrigin + y / noiseTexture.height * scale;
                var sample = Mathf.PerlinNoise(xCoord, yCoord);

                pix[(int) y * noiseTexture.width + (int) x] = new Color(sample, sample, sample);
                x++;

            }

            y++;
        }
        noiseTexture.SetPixels(pix);
        noiseTexture.Apply();
    }

    [ContextMenu("Save")]
    public void SaveTexture()
    {
        var bytes = noiseTexture.EncodeToPNG();
    }

}
