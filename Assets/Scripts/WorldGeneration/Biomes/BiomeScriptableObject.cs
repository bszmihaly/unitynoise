using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Biome")]
public class BiomeScriptableObject : ScriptableObject
{
        public string biomeName;
        public int id;
        public Color debugColor;
        public BiomeGenerator biomeGenerator;

        public GameObject pref;
}
