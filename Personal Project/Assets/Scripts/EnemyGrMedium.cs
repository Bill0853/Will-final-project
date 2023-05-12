using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyGrMedium : MonoBehaviour
{
    

    private bool playerNear;
    private float radius = 30;

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
        
        if (playerNear)
        {
            timer += Time.deltaTime;
            transform.LookAt(player.transform.position);
            
            
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
            triggerCollider.radius = radius + 15;


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
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            
            Destroy(gameObject);
        }
    }
    void LaunchProjectile() 
    { 
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
    
    
}
