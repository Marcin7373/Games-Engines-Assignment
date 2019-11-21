using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    private Tree tree;
    public Material[] material;
    private TreeEditor.TreeData treeData;
    float prog = 0.01f, speed = 0.5f, rot;

    private void Awake()
    {
        tree = GetComponent<Tree>();
    }
    void Start()
    { 
        treeData = tree.data as TreeEditor.TreeData;
        rot = transform.rotation.y + Random.rotation.y;
    }

    void Update()
    {
                  //    slowdown as it goes * half speed
        prog += Time.deltaTime * (1 - prog) * speed;
        transform.localScale = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(1, 1, 1), prog);
        transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(transform.rotation.x, rot, transform.rotation.z, transform.rotation.w), prog);
        
        treeData.UpdateMesh(tree.transform.worldToLocalMatrix, out material);
    }
}
