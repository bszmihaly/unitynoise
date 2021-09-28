using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridBase
{
    int gridX;
    int gridY;
    public float cellSize;

    public GameObject prefab;

    public Vector3 offset;
    public float[,] gridArray;

    public GridBase(int gridX, int gridY, float cellSize, Vector3 offset){
        this.gridX = gridX;
        this.gridY = gridY;
        this.cellSize = cellSize;
        this.offset = offset;
        GenerateGridArray();
        if(SettingsReader.Instance.Settings.isDebug){
            CreateDebugStuff();
        }
    }

    private void GenerateGridArray(){
        gridArray = new float[gridX,gridX];
        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                //emtpy for now
                gridArray[x,y] = default(float);
            }
        }
    }

    private void CreateDebugStuff(){
        /* GameObject empty = new GameObject();
        empty.name = "Grid_" + gridX + "_" + gridY;  */
        for (int x = 0; x < gridX; x++)
        {
            /* GameObject head = new GameObject("parent_" + x);
            head.transform.SetParent(empty.transform); */
            for (int y = 0; y < gridY; y++)
            {
                /* GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.name = "cube_" + y;
                cube.transform.SetParent(head.transform);
                cube.transform.localPosition = new Vector3(x*cellSize+0.5f, -0.5f, y*cellSize+0.5f) + offset; */

                Debug.DrawLine(new Vector3(x*cellSize, 0, y*cellSize) + offset,new Vector3(x*cellSize, 0, (y+1)*cellSize) + offset,Color.black, int.MaxValue);
                Debug.DrawLine(new Vector3(x*cellSize, 0, y*cellSize) + offset,new Vector3((x+1)*cellSize, 0, y*cellSize) + offset,Color.black, int.MaxValue);
            }
        }
        Debug.DrawLine(new Vector3(0, 0, gridY*cellSize) + offset,new Vector3(gridX * cellSize, 0, gridY * cellSize) + offset,Color.black, int.MaxValue);
        Debug.DrawLine(new Vector3(gridX*cellSize, 0, 0) + offset,new Vector3(gridX * cellSize, 0, gridY * cellSize) + offset,Color.black, int.MaxValue);
    }
}
