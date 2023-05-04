using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrMedium : MonoBehaviour
{
    [SerializeField] float enemyspeed = 5.0f;
    [SerializeField] float health = 90.0f;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(player.transform.position);
    }
}
