using System;
using System.Collections;
using UnityEngine;

public class Noise : MonoBehaviour
{
    [HideInInspector] public static string[] noiseOptions = {
        "Perlin Noise",
        "Height Colored Noise",
        "Colored Noise",
        "Rounded Color Noise",
        /*"Lines Noise",
        "Sharp Lines"*/
        };
    [HideInInspector] public static string[] maskOptions = {
        "None",
        /*"Circle"*/
        };
    [HideInInspector] public int indexForNoiseOptions;
    [HideInInspector] public int indexForMaskOptions;
    [HideInInspector] public bool autoUpdate = true;

    [HideInInspector] public Gradient gradient;

    [HideInInspector] public Vector2Int size;
    [HideInInspector] public Vector2 offset;
    [HideInInspector] public Vector2[] offsetForColor = new Vector2[3]{new Vector2(10,0), new Vector2(0,10), Vector2.zero};
    [HideInInspector] public Vector3 participateColor = new Vector3(255,255,255);
    private Vector2[] offsetForOctaves;
    private Vector2 randomizingOffset = new Vector2(2020.0f, 3045.5f);
    [HideInInspector] public float scale = 1;
    [HideInInspector] public int octaves = 1;
    [HideInInspector] public float lacunarity = 2;
    [HideInInspector] public float persistance = 0.5f;

    private Vector2[] worleyPoints;
    
    private Renderer rend;
    void Start(){
        randomizingOffset = new Vector2(UnityEngine.Random.Range(100.0f, 10000.0f), UnityEngine.Random.Range(100.0f, 10000.0f));
        /* offsetForOctaves = new Vector2[octaves]; */
        offsetForOctaves = new Vector2[]{new Vector2(0,0), new Vector2(0.1f, 0.1f), new Vector2(-0.1f, 0.1f)};
        /*for (int i = 0; i < octaves; i++)
        {
            offsetForOctaves[i] = new Vector2(UnityEngine.Random.Range(1, 10), UnityEngine.Random.Range(1, 10));
        }*/
    }

    void OnEnable(){
        GenerateTexture();
    }

    public void GenerateTexture(){
        worleyPoints = NoiseLib.prepareWorley();
        Texture2D texture = new Texture2D(size.x, size.y);
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Color color = CalculateColor(x,y);
                texture.SetPixel(x,y,color);
            }
        }
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.Apply();
        rend = gameObject.GetComponent<Renderer>();
        rend.sharedMaterial.mainTexture = texture;
    }

    Color CalculateColor(int x, int y){
        switch (indexForNoiseOptions)
        {
            case 0:
                return NoiseLib.getPerlinNoise(new Vector2Int(x,y), size, offset + randomizingOffset, scale, octaves, lacunarity, persistance, offsetForOctaves, participateColor);
            case 1:
                return TerrainMixer(x, y);
            case 2:
                return NoiseLib.getPerlinNoiseColor(new Vector2Int(x,y), size, offset + randomizingOffset, offsetForColor, scale, octaves, lacunarity, persistance, offsetForOctaves, participateColor);   
            case 3:
                return NoiseLib.getRoundedPerlinNoiseColor(new Vector2Int(x,y), size, offset + randomizingOffset, offsetForColor, scale, octaves, lacunarity, persistance, offsetForOctaves, participateColor, gradient);
            default:
                return new Color(255,0,0);
        }
    }

    Color TerrainMixer(int x, int y){
        Color biomeMarker = NoiseLib.getHeightPerlin(new Vector2Int(x,y), size, offset + randomizingOffset, scale, octaves, lacunarity, persistance, offsetForOctaves, gradient);
        if(biomeMarker.Equals(new Color(0,0,0))){
            return new Color(255, 0, 0);//NoiseLib.getPerlinNoise(new Vector2Int(x,y), size, offset + randomizingOffset, scale, octaves, lacunarity, persistance, offsetForOctaves, participateColor);
        }else{
            return NoiseLib.getPerlinNoiseColor(new Vector2Int(x,y), size, offset + randomizingOffset, offsetForColor, scale, octaves, lacunarity, persistance, offsetForOctaves, participateColor);
        }
    }
}
