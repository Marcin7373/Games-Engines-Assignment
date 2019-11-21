using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSpawn : MonoBehaviour
{
    public GameObject[] tree;
    private GameObject treeTemp;
    private List<GameObject> trees = new List<GameObject>();
    private TreeEditor.TreeData treeData;
    private float timer;
    public int treeNum = 2;
    int i = 0;

    void Start()
    {
        tree = new GameObject[treeNum];
        for (int i = 0; i < treeNum;i++) {
            treeTemp = Instantiate(tree[i], transform.position, transform.rotation);
            treeTemp.SetActive(false);
            treeData = treeTemp.GetComponent<Tree>().data as TreeEditor.TreeData;
            //treeData.root.seed = Random.Range(0, 999999);
            trees.Add(treeTemp);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5f && i < treeNum)
        {
            timer = 0;
            trees[i].SetActive(true);
            i++;
        }
    }
}
