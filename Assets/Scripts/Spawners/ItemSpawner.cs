﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public HealthPack healthPack;
    public SmallHealthPack smallHealthPack;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RandomItem", 30f, 30f);
    }

    void SpawnItem(Item item)
    {
        Instantiate(item, new Vector3(Random.Range(-15f, 15f), Random.Range(-15f, 15f), 0f), Quaternion.identity);
    }

    void RandomItem()
    {
        int rnd = Random.Range(1, 101);
        if (rnd > 20)
            SpawnItem(smallHealthPack);
        else SpawnItem(healthPack);
    }

}