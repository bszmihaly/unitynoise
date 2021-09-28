#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Settings))]
public class SettingsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Settings settingsScript = (Settings)target;
        GUILayout.Space(20f); //2 lines
        GUILayout.Label("Camera Settings", EditorStyles.boldLabel);
        if(GUILayout.Button("Switch View"))
        {
            settingsScript.switchCameraView();
        }
    }
}
#endif
