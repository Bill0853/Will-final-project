using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] bool playerNear;
    public int[] powers; 
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
        SpawnPower();
        
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == ("Player")) 
        { playerNear = true;}
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == ("Player"))
        { playerNear = false; }
    }

    public void SpawnPower();
}
