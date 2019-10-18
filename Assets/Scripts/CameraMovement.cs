using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    private float rotateY, rotateX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        
        rotateY = Input.GetAxisRaw("Vertical");
        rotateX = Input.GetAxisRaw("Horizontal");

        transform.RotateAround(transform.position, transform.right, -rotateY * speed / 4);
        transform.RotateAround(transform.position, Vector3.up, rotateX * speed / 4);
    }
}
