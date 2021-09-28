using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
 
[RequireComponent(typeof(Canvas))]
public class CanvasHelper : MonoBehaviour
{
    private static bool screenChangeVarsInitialized = false;
    private static ScreenOrientation lastOrientation = ScreenOrientation.Landscape;
    private static Vector2 lastResolution = Vector2.zero;
    private static Rect lastSafeArea = Rect.zero;
 
    private Canvas canvas;
    private RectTransform rectTransform;
    private RectTransform safeAreaTransform;
 
    void Awake()
    {
   
        canvas = GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
   
        safeAreaTransform = transform.Find("SafeArea") as RectTransform;
   
        if(!screenChangeVarsInitialized)
        {
            lastOrientation = Screen.orientation;
            lastResolution.x = Screen.width;
            lastResolution.y = Screen.height;
            lastSafeArea = Screen.safeArea;
   
            screenChangeVarsInitialized = true;
        }
       
        ApplySafeArea();
    }
 
    void Update()
    {
        if(Application.isMobilePlatform && Screen.orientation != lastOrientation)
            OrientationChanged();
   
        if(Screen.safeArea != lastSafeArea)
            SafeAreaChanged();
   
        if(Screen.width != lastResolution.x || Screen.height != lastResolution.y)
            ResolutionChanged();
    }
 
    private void ApplySafeArea()
    {
        if(safeAreaTransform == null)
            return;
   
        var safeArea = Screen.safeArea;
   
        var anchorMin = safeArea.position;
        var anchorMax = safeArea.position + safeArea.size;
        anchorMin.x /= canvas.pixelRect.width;
        anchorMin.y /= canvas.pixelRect.height;
        anchorMax.x /= canvas.pixelRect.width;
        anchorMax.y /= canvas.pixelRect.height;
   
        safeAreaTransform.anchorMin = anchorMin;
        safeAreaTransform.anchorMax = anchorMax;
    }
 
    private void OrientationChanged()
    {
        //Debug.Log("Orientation changed from " + lastOrientation + " to " + Screen.orientation + " at " + Time.time);
   
        lastOrientation = Screen.orientation;
        lastResolution.x = Screen.width;
        lastResolution.y = Screen.height;
    }
 
    private void ResolutionChanged()
    {
        //Debug.Log("Resolution changed from " + lastResolution + " to (" + Screen.width + ", " + Screen.height + ") at " + Time.time);
   
        lastResolution.x = Screen.width;
        lastResolution.y = Screen.height;
    }
 
    private void SafeAreaChanged()
    {
        // Debug.Log("Safe Area changed from " + lastSafeArea + " to " + Screen.safeArea.size + " at " + Time.time);
   
        lastSafeArea = Screen.safeArea;
        ApplySafeArea();
    }
}