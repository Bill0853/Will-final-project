using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    private GameObject player;
    public float projectileSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        transform.LookAt(player.transform.position);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(transform.forward * projectileSpeed);
    }
}
