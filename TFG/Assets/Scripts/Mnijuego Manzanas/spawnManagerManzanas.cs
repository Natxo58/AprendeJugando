using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManagerManzanas : MonoBehaviour
{
    [Header("Spawn Atributes")]
    public GameObject manzana;
    public GameObject manzanaDorada;

    public Transform[] spawnPoints;
    public float timeToSpawn;
    private float timePassed;


    // Update is called once per frame
    void Update()
    {
        if(timePassed > timeToSpawn)
        {
            spawnearManzana();
        }
        else
        {
            timePassed += Time.deltaTime;
        }
    }

    void spawnearManzana()
    {
        timePassed = 0f;
        int random = Random.Range(0, 100);
        if(random > 80)
        {
            Instantiate(manzanaDorada, spawnPoints[Random.Range(0, spawnPoints.Length)]);
        }
        else
        {
            Instantiate(manzana, spawnPoints[Random.Range(0, spawnPoints.Length)]);
        }
        
    }
}
