using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public HealthPack health;
    public SmallHealthPack smallHealthPack;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnHealthPack", 30f, 30f);
        InvokeRepeating("SpawnSmallHealthPack", 10f, 10f);
    }


    void SpawnHealthPack()
    {
        Instantiate(health, new Vector3(Random.Range(-15f, 15f), Random.Range(-15f, 15f), 0f), Quaternion.identity);
    }

    void SpawnSmallHealthPack()
    {
        Instantiate(smallHealthPack, new Vector3(Random.Range(-15f, 15f), Random.Range(-15f, 15f), 0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
