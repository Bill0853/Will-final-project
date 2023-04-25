using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    protected bool PlayerNear;
    //public ObjectOpen objectOpen;
    public PlayerController playerOpen;


    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
       if (playerOpen)
        {
            Destroy(gameObject);
        }
    }
}
