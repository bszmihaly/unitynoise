using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField] private GameObject buildingPrefab;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        GridBase grid = new GridBase(10, 10, 1, new Vector3(0,0,0));


        //TESTING CODE START ---------------------------------------
        
        for (int i = 0; i < grid.gridArray.GetLength(0); i++)
        {
            GameObject full = new GameObject(i.ToString());
            full.transform.SetParent(parent.transform);
            for (int j = 0; j < grid.gridArray.GetLength(1); j++)
            {
                GameObject prefab = Instantiate(buildingPrefab,new Vector3(i*grid.cellSize+grid.cellSize/2,0,j*grid.cellSize+grid.cellSize/2) + grid.offset, new Quaternion(0,0,0,0));
                prefab.name = j.ToString();
                prefab.transform.localScale = new Vector3(grid.cellSize, grid.cellSize, grid.cellSize);
                prefab.transform.SetParent(full.transform);
            }
        }

        //TESTING CODE END -----------------------------------

        //GridBase<float> grid2 = new GridBase<float>(10, 4, 1, new Vector3(-11,0,-5));
        //GridBase<float> grid3 = new GridBase<float>(5, 4, 0.5f, new Vector3(-19,0,1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
