using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    public BiomeScriptableObject[] biomes;
    public Vector2Int fragmentSize;
    public Vector2Int fragmentsInWorld;
    //filter the noise to get biomes.Length different colors that represent biomes -> pass the generate to the according biomegenerator
    void Start()
    {
        //generateWorld();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void generateWorld(){
        Debug.Log("STARTING GENERATION");
        Gradient gradient = new Gradient();
        GradientColorKey[] ckeys = new GradientColorKey[biomes.Length];

        for (int i = 0; i < biomes.Length; i++)
        {
            ckeys[i] = new GradientColorKey(biomes[i].debugColor,1/biomes.Length * i);
        }
        gradient.SetKeys(ckeys, new GradientAlphaKey[]{new GradientAlphaKey(1,1)});
        Debug.Log("gradient done, Length:" + gradient.colorKeys.Length);
        for (int i = 0; i < fragmentsInWorld.x; i++)
        {
            for (int j = 0; j < fragmentsInWorld.y; j++)
            {
                Debug.Log("Fragment generation about to begin:" + i + "_" + j);
                GenerateFragment.Generate(biomes, gradient, fragmentSize, new Vector2(i*fragmentSize.x, j*fragmentSize.y));
            }
        }
    }
}
