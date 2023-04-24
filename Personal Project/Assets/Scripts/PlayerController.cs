using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection; //Use for 

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float xMove;
    private float zMove;
    
    public float speed = 10;
    public float jumpForce = 900;
    public float gravityModifier;
    public float fallSpeed;

    public LayerMask groundLayer;
    public float distToGround = 0.1f;
    public bool groundedTest = false;

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
            groundedTest = false; }
    }
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
    //bool IsGrounded()
    //{Vector3 position = transform.position; Vector3 direction = Vector3.down;        float distance = 1.0f;        RaycastHit hit = Physics.Raycast(position, direction, distance, groundLayer);        if (hit.collider != null) { return true; }        return false; }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

   
   
}
