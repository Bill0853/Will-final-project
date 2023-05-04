using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection; //Use for 

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float xMove;
    private float zMove;
    
    private float speed = 450;
    private float jumpForce = 600;
    private float gravityModifier = 0.5f;
    private float fallSpeed = 100000;
    private LayerMask groundLayer;
    private float distToGround = 1;

    [SerializeField] float powerUpSpeed = 0;
    [SerializeField] float powerUpJump = 0;
    

    
    
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
        rb.AddRelativeForce(Vector3.forward * speed * (powerUpSpeed + 1) * xMove);
        rb.AddRelativeForce(Vector3.right * speed * (powerUpJump + 1) * zMove);
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
        rb.AddForce(Vector3.up * jumpForce * (powerUpJump + 1), ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == ("PowerupJump"))
        { 
            powerUpJump += 0.2f;
            Destroy (collision.gameObject);
        }
        if (collision.gameObject.tag == ("PowerupSpeed"))
        {
            powerUpSpeed += 0.15f;
            Destroy(collision.gameObject);
        }
    }

}
