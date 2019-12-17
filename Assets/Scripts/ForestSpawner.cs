using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestSpawner : MonoBehaviour
{
    public GameObject spawnerTemp;
    private int rows, cols;
    public GameObject[,] spawner;
    private Transform tr;
    private float width, length, lGap= 5, wGap = 5, randGap, edgeOffset = 40f;
    private Vector3 pos;

    void Awake()
    {
        tr = GetComponent<Transform>();
        width = tr.localScale.x* 10 - edgeOffset;
        length = tr.localScale.z* 10 - edgeOffset;
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
                float perlinNoise = (Mathf.PerlinNoise(c/1.3f, r/1.3f) -0.5f) * 4;
                Debug.Log(perlinNoise);
                if (randGap != 0) {
                    randGap = Random.Range(4, cols/2);
                    pos = new Vector3(tr.position.x - (width / 2) + (wGap * c)+perlinNoise, tr.position.y+20f, tr.position.z - (length / 2) + (r * lGap)+perlinNoise);
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
