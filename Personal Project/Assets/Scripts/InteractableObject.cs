using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] bool playerNear;
    [SerializeField] GameObject[] powerUps;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("f") && playerNear)
        {
            OpenInteractable();
        }
    }

    void OpenInteractable()
    {
        
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == ("Player")) 
        { playerNear = true;}
    }
    
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == ("Player"))
        { playerNear = false; }
    }

    
    
}
