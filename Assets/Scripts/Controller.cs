using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;
    private float move, rotate, speed = 100;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        move = Input.GetAxisRaw("Vertical");
        rotate = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(rotate, 0.0f, move);
       
        rb.AddForce(movement * speed * Time.deltaTime);
     
        //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.y+ move * speed * Time.deltaTime);
        //rb.MoveRotation(new Quaternion(rb.rotation.x, rb.rotation.y+rotate, rb.rotation.z, rb.rotation.w));
    }
}
