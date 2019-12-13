using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestSpawner : MonoBehaviour
{
    public GameObject spawnerTemp;
    private int rows, cols;
    public GameObject[,] spawner;
    private Transform tr;
    private float width, length, lGap= 5, wGap = 5;

    void Awake()
    {
        tr = GetComponent<Transform>();
        width = tr.localScale.x -1;
        length = tr.localScale.y -1;
        cols = (int)(width/lGap);
        rows = 5;
        spawner = new GameObject[cols,rows];
    }

    void Start()
    {

        int j = 0, k = 0;
        for (int i = 0; i < cols*rows; i++)
        {           
            if (k%cols == 0){
                j++;
                k = 0;
            }
            Vector3 pos = new Vector3(tr.position.x - (width/2) + (lGap*k), tr.position.y, tr.position.z - (length/2) + 55 + (j*wGap));
            spawner[k,j] = Instantiate(spawnerTemp, pos, transform.rotation);
            spawner[k,j].transform.parent = tr;
            k++;
        }
    }

    void Update()
    {
        
    }
}
