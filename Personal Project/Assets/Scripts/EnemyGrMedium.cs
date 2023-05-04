using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrMedium : MonoBehaviour
{
    [SerializeField] float enemyspeed = 5.0f;
    [SerializeField] float health = 90.0f;
    private bool playerNear;
    private float radius = 20;
     
    [SerializeField] SphereCollider triggerCollider;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerNear = false;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (playerNear)
        {
            transform.LookAt(player.transform.position);
        }

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            playerNear = true;
            triggerCollider.radius = radius + 10;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == ("Player"))
        { 
            playerNear = false;  
            triggerCollider.radius = radius;
        }
    }

    
    
}
