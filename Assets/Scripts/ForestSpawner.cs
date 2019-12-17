using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestSpawner : MonoBehaviour
{
    public GameObject spawnerTemp;
    private int rows, cols;
    public GameObject[,] spawner;
    private Transform tr;
    private float width, length, lGap= 8, wGap = 5, randGap;

    void Awake()
    {
        tr = GetComponent<Transform>();
        width = tr.localScale.x;
        length = tr.localScale.y;
        cols = (int)(width/wGap)+1;
        rows = (int)(length/lGap)+1;
        spawner = new GameObject[cols,rows];
    }

    void Start()
    {
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (randGap != 0) {
                    randGap = Random.Range(4, cols/2);
                    Vector3 pos = new Vector3(tr.position.x - (width / 2) + (wGap * c), tr.position.y, tr.position.z - (length / 2) + (r * lGap));
                    spawner[c, r] = Instantiate(spawnerTemp, pos, transform.rotation);
                    spawner[c, r].transform.parent = tr;
                }
                randGap--;
            }
            
        }
    }

    void Update()
    {
        
    }
}
