using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSpawn : MonoBehaviour
{
    public static int treeNum = 3;
    public GameObject[] tree = new GameObject[treeNum];
    private GameObject[] treeTemp = new GameObject[treeNum];
    private Transform player;
    private float timer, rate = 1f;   
    private int j = 0;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Start()
    {
        for (int i = 0; i < treeNum; i++) {
            treeTemp[i] = Instantiate(tree[i], transform.position, transform.rotation);
            treeTemp[i].transform.localScale = new Vector3(0.01f,0.01f,0.01f);
            treeTemp[i].transform.parent = transform;
            treeTemp[i].SetActive(false);       
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > rate && j < treeNum)
        {
            treeTemp[j].SetActive(true);
            timer = 0;
            j++;
        }
    }
}
