using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeGenerator
{
    public Color debugC = new Color(0,0,0);
    public virtual Color generate(){
        return debugC;
    }
}
