#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Noise))]
public class NoiseEditor : Editor
{
    private Noise noise;
    public override void OnInspectorGUI()
    {
        noise = (Noise)target;

        EditorGUILayout.BeginHorizontal();
        noise.autoUpdate = EditorGUILayout.ToggleLeft("Auto Update", noise.autoUpdate);
        if(GUILayout.Button("Generate")){
            noise.GenerateTexture();
        }
        EditorGUILayout.EndHorizontal();
        GUILayout.Space(10f);

        noise.indexForNoiseOptions = EditorGUILayout.Popup("Noise Type",noise.indexForNoiseOptions, Noise.noiseOptions);
        noise.indexForMaskOptions = EditorGUILayout.Popup("Mask Type",noise.indexForMaskOptions, Noise.maskOptions);

        noise.lacunarity = EditorGUILayout.FloatField("Lacunarity", noise.lacunarity);
        noise.persistance = EditorGUILayout.FloatField("Persistance", noise.persistance);
        noise.octaves = EditorGUILayout.IntSlider("Octaves", Mathf.Abs(noise.octaves), 1, 3);
        
        noise.gradient = EditorGUILayout.GradientField("Coloring Gradient", noise.gradient);
        noise.participateColor.x = EditorGUILayout.Slider("Red", noise.participateColor.x, 0, 255);
        noise.participateColor.y = EditorGUILayout.Slider("Green", noise.participateColor.y, 0, 255);
        noise.participateColor.z = EditorGUILayout.Slider("Blue", noise.participateColor.z, 0, 255);
        GUILayout.Space(20f); //2 lines
        noise.size = EditorGUILayout.Vector2IntField("Size", noise.size);
        noise.scale = EditorGUILayout.FloatField("Scale", noise.scale);
        noise.offset = EditorGUILayout.Vector2Field("Offset", noise.offset);
        if(noise.indexForNoiseOptions == 1 || noise.indexForNoiseOptions == 2){
            noise.offsetForColor[0] = EditorGUILayout.Vector2Field("Red Offset", noise.offsetForColor[0]);
            noise.offsetForColor[1] = EditorGUILayout.Vector2Field("Green Offset", noise.offsetForColor[1]);
            noise.offsetForColor[2] = EditorGUILayout.Vector2Field("Blue Offset", noise.offsetForColor[2]);
        }
        //DrawDefaultInspector();
        if(GUI.changed && noise.autoUpdate)
        {
            noise.octaves = Mathf.Abs(noise.octaves);
            noise.GenerateTexture();
        }
    }
}
#endif