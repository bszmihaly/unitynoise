using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHide : MonoBehaviour
{
    private bool Visible = false;
    public void ShowHideFunc(){
        Visible = !Visible;
        gameObject.SetActive(Visible);
    }
}