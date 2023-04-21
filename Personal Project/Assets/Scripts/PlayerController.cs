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
       
            //&& IsGrounded())
    }

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

   
   
}
