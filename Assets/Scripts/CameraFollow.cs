using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraTarget;
    private float distY, distZ, angle; 
    public float distH = 15f;
    
    void Start()
    {
        angle = transform.eulerAngles.x * Mathf.Deg2Rad;
        distZ = Mathf.Cos(angle) * distH;
        distY = Mathf.Sin(angle) * distH;
    }

    void Update()
    {        
        transform.position = Vector3.Lerp(transform.position, new Vector3(cameraTarget.position.x, distY, cameraTarget.position.z - distZ), Time.deltaTime*6);

    }
}
