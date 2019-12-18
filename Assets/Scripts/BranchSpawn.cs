using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSpawn : MonoBehaviour
{
    public static int treeNum = 3;
    public GameObject[] tree = new GameObject[treeNum];
    private GameObject[] treeTemp = new GameObject[treeNum];
    private Transform player;  
    private RaycastHit hit;
    private Ray ray;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        ray = new Ray(transform.position, -Vector3.up);
    }

    void Start()
    {
        if (Physics.Raycast(ray, out hit, 70f))
        {
            transform.position = hit.point;
        }

        for (int i = 0; i < treeNum; i++) {
            treeTemp[i] = Instantiate(tree[i], transform.position, transform.rotation);
            treeTemp[i].transform.localScale = new Vector3(0.01f,0.01f,0.01f);
            treeTemp[i].transform.parent = transform;     
        }
    }

    void Update()
    {
        
    }
}
