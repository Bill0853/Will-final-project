using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection; //Use for 

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    //player movement variables
    private float verticalInput;
    private float horizontalInput;
    public float speed = 10;
    public float topSpeed = 1000.0f;
    public float jumpForce;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();     
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Player Movement on the x and z axis
        playerRb.AddRelativeForce(Vector3.forward * speed * verticalInput);
        playerRb.AddRelativeForce(Vector3.right * speed /2 * horizontalInput);
        
        //Limits the max velocity of the player
        if (GetComponent<Rigidbody>().velocity.magnitude > topSpeed)
        {
            Debug.Log("velocity caps");
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * topSpeed;
        }
        
        if (Input.GetKey("space")) { playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); }

        //when you call this function it will clear the console
        if (Input.GetKey("c"))
        {
            ClearLog();
        }
    }

    public void ClearLog() //Clear Debug Console
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
}
