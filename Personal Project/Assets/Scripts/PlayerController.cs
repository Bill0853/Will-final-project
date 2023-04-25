using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection; //Use for 

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float xMove;
    private float zMove;
    
    private float speed = 500;
    private float jumpForce = 600;
    public float gravityModifier = 0.5f;
    public float fallSpeed = 100000;

    public LayerMask groundLayer;
    public float distToGround = 1;
    public bool groundedTest = false;

    public bool playerOpen = false;

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
        if (Input.GetKey("space"))
        if (Input.GetKeyDown("space") && IsGrounded())
        {
            Jump();
        }
        if (IsGrounded()) 
        {
            groundedTest = true;
        }   
        if (!IsGrounded()) { 
            rb.AddRelativeForce(-Vector3.up * gravityModifier * fallSpeed * Time.deltaTime);
            groundedTest = false; 
        }



        //Player interactions with interactables
        if (Input.GetKey("f"))
        { playerOpen = true; }
        else { playerOpen = false; }
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
