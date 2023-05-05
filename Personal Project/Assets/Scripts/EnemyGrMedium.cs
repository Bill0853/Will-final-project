using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrMedium : MonoBehaviour
{
    [SerializeField] float enemyspeed = 5.0f;
    [SerializeField] float health = 90.0f;
    private bool playerNear;
    private float radius = 20;

    private GameObject rb;
    [SerializeField] SphereCollider triggerCollider;
    [SerializeField] GameObject player;

    [SerializeField] GameObject projectile;
    [SerializeField] float launchDelay = 3.0f;
    public bool attack;
    public float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
        playerNear = false;
        player = GameObject.Find("Player");
        timer = 0;
        attack = true;

    }

    void Update()
    { 
        timer += Time.deltaTime;
        
        if (playerNear)
        {
            transform.LookAt(player.transform.position);
            
            //attack manager
            // Add the time since Update was last called to the timer.
           

            // This will trigger an action every 2 seconds
            if (attack && timer >= launchDelay)
            {
                timer -= launchDelay;
                attack = false;
                LaunchProjectile();
            }
            else if (!attack && timer >= launchDelay)
            {
                attack = true;
            }
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
    void LaunchProjectile() 
    { 
        Instantiate(projectile, rb.transform.position);
        
    }

}
