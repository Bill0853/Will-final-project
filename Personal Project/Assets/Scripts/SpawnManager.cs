using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnDelay;
    public float spawnInterval;

    public float xRange;
    public float ySpawn = 15.0f;
    public float zRange;
    private Vector3 randomSpawn;

    public GameObject chest;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnChest", spawnDelay, spawnInterval );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnChest()
    {
        RandomLocation();
        Instantiate(chest, randomSpawn, Quaternion.identity);
    }

    void RandomLocation()
    {
        var xSpawn = Random.Range(-xRange, xRange);
        //var ySpawn = Random.Range(-yRange, yRange);
        var zSpawn = Random.Range(-zRange, zRange);
        randomSpawn = new Vector3(xSpawn, ySpawn, zSpawn);
    }
   
}