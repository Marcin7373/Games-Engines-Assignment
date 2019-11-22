using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSpawn : MonoBehaviour
{
    public static int treeNum = 3;
    public GameObject[] tree = new GameObject[treeNum];
    private GameObject[] treeTemp = new GameObject[treeNum];
    private float timer;   
    private int j = 0;

    void Start()
    {
        for (int i = 0; i < treeNum; i++) {
            treeTemp[i] = Instantiate(tree[i], transform.position, transform.rotation);
            treeTemp[i].transform.localScale = new Vector3(0.1f,0.1f,0.1f);
            treeTemp[i].SetActive(false);       
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5f && j < treeNum)
        {         
            treeTemp[j].SetActive(true);
            timer = 0;
            j++;
        }
    }
}
