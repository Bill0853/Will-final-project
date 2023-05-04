using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] bool playerNear;
    [SerializeField] GameObject[] powerUps;
    public int spawnedChests;
    public SpawnManager spawnManager;
    private bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GetComponent<SpawnManager>();
        isOpen = false;
    }

    void Update()
    {
        if (Input.GetKey("f") && playerNear && !isOpen)
        {
           OpenInteractable();
        }

        if (isOpen == true)
        {
            Destroy(gameObject);
        }
    }

    void OpenInteractable()
    {
        int index = Random.Range(0, powerUps.Length);
        Instantiate((powerUps[index]), transform.position, Quaternion.identity);
        isOpen = true;
    }
    
    //Player is near
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
