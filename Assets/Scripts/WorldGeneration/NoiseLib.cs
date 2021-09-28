using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class NoiseLib
{
    public static float getPerlinNoiseInternal(Vector2Int pos, Vector2Int size, Vector2 offset,
                                float scale, int octaves, float lacunarity,
                                float persistance, Vector2[] offsetForOctaves){
        //
        float maxNoiseHeight = float.MaxValue;
        float minNoiseHeight = float.MinValue;
        float amplitude = 1;
		float frequency = 1;
		float noiseHeight = 0;
        offsetForOctaves = new Vector2[]{new Vector2(0, 0), new Vector2(0.1f, 0.2f), new Vector2(-0.1f, 0.2f)};
        for (int i = 0; i < octaves; i++){
            float sampleX = (offset.x + ((pos.x - (size.x/2)) * scale + offsetForOctaves[i].x) / size.x) * frequency;
            float sampleY = (offset.y + ((pos.y - (size.y/2)) * scale + offsetForOctaves[i].y) / size.y) * frequency;
            float pValue = Mathf.PerlinNoise(sampleX,sampleY);
            noiseHeight += pValue * amplitude;
            amplitude *= persistance;
			frequency *= lacunarity;
        }
        if (noiseHeight > maxNoiseHeight)
        {
            noiseHeight = maxNoiseHeight;
        }
        else if (noiseHeight < minNoiseHeight)
        {
            noiseHeight = minNoiseHeight;
        }
        noiseHeight = 1 - noiseHeight;
        return noiseHeight;
    }

    public static Color getPerlinNoise(Vector2Int pos, Vector2Int size, Vector2 offset,
                                float scale, int octaves, float lacunarity,
                                float persistance, Vector2[] offsetForOctaves, Vector3 partColor){
        //
        float noiseHeight = getPerlinNoiseInternal(pos, size, offset, scale, octaves, lacunarity, persistance, offsetForOctaves);
        return Color.Lerp(new Color(1, 1, 1), new Color(partColor.x/255, partColor.y/255, partColor.z/255), noiseHeight);
    }

    public static Color getPerlinNoiseColor(Vector2Int pos, Vector2Int size, Vector2 offset,Vector2[] offsetForColor,
                                float scale, int octaves, float lacunarity,
                                float persistance, Vector2[] offsetForOctaves, Vector3 partColor){
        //
        float r = (partColor.x/255) * getPerlinNoiseInternal(pos, size, offset + offsetForColor[0], scale, octaves, lacunarity, persistance, offsetForOctaves);
        float g = (partColor.y/255) * getPerlinNoiseInternal(pos, size, offset + offsetForColor[1], scale, octaves, lacunarity, persistance, offsetForOctaves);
        float b = (partColor.z/255) * getPerlinNoiseInternal(pos, size, offset + offsetForColor[2], scale, octaves, lacunarity, persistance, offsetForOctaves);
        return new Color(r,g,b);
    }

    public static Color getRoundedPerlinNoiseColor(Vector2Int pos, Vector2Int size, Vector2 offset,Vector2[] offsetForColor,
                                float scale, int octaves, float lacunarity,
                                float persistance, Vector2[] offsetForOctaves, Vector3 partColor, Gradient grad){
        //
        Color c = getPerlinNoiseColor(pos, size, offset, offsetForColor, scale, octaves, lacunarity, persistance, offsetForOctaves, partColor);
        float[] distances = new float[grad.colorKeys.Length];
        for(int i = 0; i< grad.colorKeys.Length; i++)
        {
            Vector4 cv4 = c;
            Vector4 carrayv4 = grad.colorKeys[i].color;
            distances[i] = Vector3.Distance(cv4, carrayv4);
        }
        float shortestD = Mathf.Min(distances);
        int index = Array.IndexOf(distances,shortestD);
        return grad.colorKeys[index].color;
    }

    public static Color getHeightPerlin(Vector2Int pos, Vector2Int size, Vector2 offset,
                                float scale, int octaves, float lacunarity,
                                float persistance, Vector2[] offsetForOctaves, Gradient grad){
        //
        return grad.Evaluate(getPerlinNoiseInternal(pos, size, offset, scale, octaves, lacunarity, persistance, offsetForOctaves));
    }
    public static Vector2[] prepareWorley(){
        return new Vector2[]{};
    }
}