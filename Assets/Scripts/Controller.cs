using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    private Rigidbody rb;
    private MeshRenderer mr;
    private float move, rotate, speed = 100, dashCooldown = 0;
    private bool dashing;
    private Vector3 movement;
    public Material[] mat;
    private SphereCollider sCollider;
    public float dashLength = 1.5f, cooldownRate = 0.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        sCollider = GetComponent<SphereCollider>();
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
            dashCooldown -= Time.deltaTime * cooldownRate;
            dashing = false;
            mr.material = mat[0];
            Physics.IgnoreLayerCollision(0, 8, false);
        }
        else if (dashing) //dashing
        {
            dashCooldown += Time.deltaTime;
            if (dashCooldown >= dashLength) //dash length
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            SceneManager.LoadScene(0);
        }
    }
}
