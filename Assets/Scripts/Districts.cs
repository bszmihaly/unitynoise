using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Districts
{
    public int area;
    public Color borderColor;
    public Color32 tileColor;
    public string name;
}

public class CityCenter : Districts
{
    public CityCenter(){
        name = "City Center";
        borderColor = new Color(0, 255, 0);
        area = 25;
    }
}