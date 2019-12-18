using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSpawn : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;

    void Awake()
    {
        ray = new Ray(transform.position, -Vector3.up); //will spawn above the mesh
    }

    void Start()
    {
        if (Physics.Raycast(ray, out hit, 70f))
        {
            transform.position = new Vector3(hit.point.x, hit.point.y+2, hit.point.z);
        }
    }

  
    void Update()
    {
        
    }
}
