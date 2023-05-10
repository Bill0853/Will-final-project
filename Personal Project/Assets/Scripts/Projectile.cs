using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    private float timer;
    private GameObject target;
    public float projectileSpeed = 40;
    private bool playerNear;
    private bool startTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        playerNear = false;
        target = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();      
    }
    void Update() 
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
        }
        if (timer < 0.1) 
        {
            transform.LookAt(target.transform.position); 
        }
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
        if (timer > 4) { Destroy(gameObject); }
    }
    
    void Awake() 
    {
        startTimer = true;
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag != ("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}
