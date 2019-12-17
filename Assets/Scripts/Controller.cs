using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;
    private MeshRenderer mr;
    private float move, rotate, speed = 100, dashCooldown = 0;
    private bool dashing;
    private Vector3 movement;
    public Material[] mat;
    private SphereCollider sCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        sCollider = GetComponent<SphereCollider>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        move = Input.GetAxisRaw("Vertical");
        rotate = Input.GetAxisRaw("Horizontal");
        if (!dashing && dashCooldown <= 0)
        {
            dashing = Input.GetButtonDown("Jump");
            dashCooldown = 0;
        }
        movement = new Vector3(rotate, 0.0f, move);

        if (dashing)
        {
            
            //sCollider.enabled = false;
        }
        else
        {
            
            
        }
     
        //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.y+ move * speed * Time.deltaTime);
        //rb.MoveRotation(new Quaternion(rb.rotation.x, rb.rotation.y+rotate, rb.rotation.z, rb.rotation.w));
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * speed * Time.deltaTime);
        Dash();
    }

    void Dash()
    {
        if (dashCooldown > 0 && !dashing) //delay to dash again
        {
            dashCooldown -= Time.deltaTime * 2;
            dashing = false;
            mr.material = mat[0];
            Physics.IgnoreLayerCollision(0, 8, false);
        }
        else if (dashing) //dashing
        {
            dashCooldown += Time.deltaTime;
            if (dashCooldown >= 1.5f) //dash length
            {
                dashing = false;
            }
            mr.material = mat[1];
            Physics.IgnoreLayerCollision(0, 8, true);
        }
        else
        {
            mr.material = mat[2];
        }
    }
}
