using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSpawn : MonoBehaviour
{
    public static int treeNum = 3;
    public GameObject[] tree = new GameObject[treeNum];
    private GameObject[] treeTemp = new GameObject[treeNum];
    private TreeEditor.TreeData treeData;
    private float timer;   
    private int j = 0;

    void Start()
    {
        for (int i = 0; i < treeNum; i++) {
            treeTemp[i] = Instantiate(tree[i], transform.position, transform.rotation);
            treeTemp[i].SetActive(false);
            treeData = treeTemp[i].GetComponent<Tree>().data as TreeEditor.TreeData;
            treeData.root.seed = Random.Range(0, 999999);
            
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.5f && j < treeNum)
        {
            timer = 0;
            treeTemp[j].SetActive(true);
            j++;
        }


    }
}
