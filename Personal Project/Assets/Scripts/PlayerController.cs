using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection; //Use for 

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float xMove;
    private float zMove;
    
    public float speed = 500;
    public float jumpForce = 600;
    private float gravityModifier = 0.5f;
    private float fallSpeed = 100000;

    private LayerMask groundLayer;
    private float distToGround = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        zMove = Input.GetAxis("Horizontal");
        xMove = Input.GetAxis("Vertical");

        //Player Movement on the x and z axis
        rb.AddRelativeForce(Vector3.forward * speed * xMove);
        rb.AddRelativeForce(Vector3.right * speed * zMove);
        if (Input.GetKeyDown("space") && IsGrounded())
        {
            Jump();
        }
       
        if (!IsGrounded()) { 
            rb.AddRelativeForce(-Vector3.up * gravityModifier * fallSpeed * Time.deltaTime);
        }
    }


    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }


    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

   
   
}
