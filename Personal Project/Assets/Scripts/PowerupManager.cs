using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public GameObject[] powers;
   
    // Start is called before the first frame update

    public Gameobject GetPowerUp()
    {
        PickRandom(powers);
    }
}
