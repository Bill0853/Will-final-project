using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection; //Use for 

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float verticalInput;
    private float horizontalInput;
    [SerializeField] float speed = 10;
    [SerializeField] float topSpeed = 1000.0f;
    public float jumpForce = 900;
    public bool isOnGround = true;
    public float gravityModifier;
    public bool isFast = false;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();  
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Player Movement on the x and z axis
        if (isOnGround) 
        {
            playerRb.AddRelativeForce(Vector3.forward * speed * verticalInput);
            playerRb.AddRelativeForce(Vector3.right * speed / 2 * horizontalInput);
        }
        else
        {
            playerRb.AddRelativeForce(Vector3.forward * speed /2 * verticalInput);
            playerRb.AddRelativeForce(Vector3.right * speed /4 * horizontalInput);
        }
        //Limits the max velocity of the player
        if (playerRb.velocity.magnitude > topSpeed)
        {
           isFast = true;
            playerRb.velocity = playerRb.velocity.normalized * topSpeed;
        }
        else
        {
            isFast = false;
        }

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
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
