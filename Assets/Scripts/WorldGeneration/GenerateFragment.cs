using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenerateFragment
{
    public static void Generate(BiomeScriptableObject[] biomes, Gradient gradient, Vector2Int fragmentSize, Vector2 fragmentCoord){
        Debug.Log("Fragment generation begun");
        Color[] cArray = new Color[biomes.Length];
        for (int i = 0; i < biomes.Length; i++)
        {
            cArray[i] = biomes[i].debugColor;
        }
        GameObject empt = new GameObject(fragmentCoord.x + "_" + fragmentCoord.y);
        Debug.Log("Empty exists");
        for (int i = 0; i < fragmentSize.x; i++)
        {
            GameObject xempty = new GameObject(i.ToString());
            xempty.transform.SetParent(empt.transform);
            for (int j = 0; j < fragmentSize.y; j++)
            {
                Color biomeMarker = NoiseLib.getHeightPerlin(new Vector2Int(i,j), fragmentSize, fragmentCoord * fragmentSize,
                1, 3, 2, 0.5f, new Vector2[]{new Vector2(0,0), new Vector2(0.5f, 0.9f), new Vector2(-0.5f, 0.6f)}, gradient);
                for(int h = 0; h < biomes.Length; j++){
                    if(biomeMarker.Equals(cArray[i])){
                        GameObject g = GameObject.Instantiate(biomes[i].pref,new Vector3(fragmentCoord.x+i,0,fragmentCoord.y+j),Quaternion.identity);
                        Debug.Log(g);
                        Debug.Log("tile doen");
                        g.transform.SetParent(xempty.transform);
                    }
                }
            }
        }
    }
}
