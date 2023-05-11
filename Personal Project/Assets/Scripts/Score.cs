using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    //public SpawnManager spawnManager;
    public float timeAlive;
     
    public TMP_Text scoreText;

  

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;

        scoreText.text = "Score: " + timeAlive.ToString("0");
       
    }
}
