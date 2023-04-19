using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection; //Use for 

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float xMove;
    private float zMove;
    private bool isOnGround = true;
    [SerializeField] float speed = 10;
    public float jumpForce = 900;
    public float gravityModifier;
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        zMove = Input.GetAxis("Horizontal");
        xMove = Input.GetAxis("Vertical");

        //Player Movement on the x and z axis
        rb.AddRelativeForce(Vector3.forward * speed * xMove);
        rb.AddRelativeForce(Vector3.right * speed * zMove);
        
       


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
        ApplyGravity();
    }    

    private void OnCollisionEnter(Collision collision) { isOnGround = true; NoGravity();  }

    //private void ApplyGravity()
    //{
    //    Physics.gravity *= gravityModifier);
    //}
    //private void NoGravity()
    //{
    //    Physics.gravity /= gravityModifier);
    //}

    public void ClearLog() //Clear Debug Console
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
}
