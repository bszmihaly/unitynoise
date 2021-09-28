using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings")]
public class Settings : ScriptableObject
{
    [SerializeField] private bool isDebugVar = true;
    public bool isDebug {get {return isDebugVar;}}
    private bool isPerspective = false;

    public void switchCameraView(){
        if(isPerspective){
            Camera.main.GetComponent<CameraControls>().isPerspective = false;
            Camera.main.GetComponent<Transform>().rotation = Quaternion.Euler(30, 45, 0);
            Camera.main.GetComponent<Camera>().orthographic = true;
        }else{
            Camera.main.GetComponent<CameraControls>().isPerspective = true;
            Camera.main.GetComponent<Transform>().rotation = Quaternion.Euler(50, 45, 0);
            Camera.main.GetComponent<Camera>().orthographic = false;
        }
        isPerspective = !isPerspective;
    }
}
