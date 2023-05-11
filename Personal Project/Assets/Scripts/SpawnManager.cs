using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] float waveSpawnDelay = 15;
    [SerializeField] float enemysToSpawn = 0;
    [SerializeField] float waveTimer;
    public float waveCounter;
    public TMP_Text waveCounterText;
    public GameObject enemy;

    public float xRange;
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

        

        if (waveTimer > waveSpawnDelay)
        {
            SpawnWave();
            waveTimer = 0;
        }

        waveCounterText.text = waveCounter.ToString("0");

        if (spawnedChests < maxChests)
        {
            spawnedChests++;
            SpawnChest();

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
        randomSpawn = new Vector3(xSpawn, 10, zSpawn);
    }

    void SpawnWave()
    {
        waveCounter ++;
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
