using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] float waveSpawnDelay = 15;
    [SerializeField] float enemysToSpawn = 3;
    [SerializeField] float waveTimer;
    public GameObject enemy;
    public float x;

    public float xRange;
    public float ySpawn = 15.0f;
    public float zRange;
    private Vector3 randomSpawn;


    public GameObject chest;
    public int spawnedChests = 1;
    public int maxChests = 5;
    public float moreChest;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        waveTimer += Time.deltaTime;
        if (moreChest > 2)
        {
            moreChest = 0;
            maxChests++;
        }

        if (spawnedChests < maxChests)
        {
            spawnedChests++;
            SpawnChest();

        }

        if (waveTimer > waveSpawnDelay)
        {
            SpawnWave();
            waveTimer = 0;
        }
         
        
    }

    void SpawnChest()
    {
        RandomLocation();
        Instantiate(chest, randomSpawn, Quaternion.identity);
    }



    void RandomLocation()
    {
        var xSpawn = Random.Range(-xRange, xRange);
        var zSpawn = Random.Range(-zRange, zRange);
        randomSpawn = new Vector3(xSpawn, ySpawn, zSpawn);
    }

    void SpawnWave()
    {
        enemysToSpawn = enemysToSpawn + 1;
        moreChest = moreChest + 1;
        for (int i = 0; i < enemysToSpawn; i++) { SpawnEnemy(); }
    }
    void SpawnEnemy()
    {
        RandomLocation();
        Instantiate(enemy, randomSpawn, Quaternion.identity);
    }
}
