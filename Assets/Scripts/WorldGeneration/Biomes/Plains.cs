using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plains : BiomeGenerator
{
    public override Color generate(){
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                //NoiseLib.getPerlinNoiseColor()
            }
        }
        return new Color(0,0,0);
    }
}
