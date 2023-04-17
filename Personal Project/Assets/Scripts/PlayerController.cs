using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection; //Use for 

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float xMove;
    private float zMove;
    [SerializeField] float speed = 10;
    //[SerializeField] float topSpeed = 1000.0f;
    public float jumpForce = 900;
    public bool isOnGround = true;
    public float gravityModifier;
    public float strength;
    public float maxSpeed;
    //public bool isFast = false;


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
        if (isOnGround)
        {
            rb.AddRelativeForce(Vector3.forward * speed * xMove);
            rb.AddRelativeForce(Vector3.right * speed * zMove);
        }
        else
        {
            rb.AddRelativeForce(Vector3.forward * speed / 2 * xMove);
            rb.AddRelativeForce(Vector3.right * speed / 2 * zMove);
        }

        //Limits the max velocity of the player
        //if (rb.velocity.magnitude > topSpeed)
        //{
        //   isFast = true;
        //    rb.velocity = rb.velocity.normalized * topSpeed;
        //}
        //else
        //{
        //    isFast = false;
        //}

        if (Input.GetKey("space") && isOnGround)
        {
            Jump();
        }

            if (Input.GetKey("c"))
        { 
            ClearLog();
        }    
    }
    
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
    }    

    private void OnCollisionEnter(Collision collision) { isOnGround = true; }
        
    
   
    public void ClearLog() //Clear Debug Console
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
}
