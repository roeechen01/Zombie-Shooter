using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {
    public SimpleZombie prefabSimpleZombie;
    public FastZombie prefabFastZombie;
    public GhostZombie prefabGhostZombie;
    Portal[] portals;

	// Use this for initialization
	void Start () {
        portals = FindObjectsOfType<Portal>();
        InvokeRepeating("SpawnSimpleZombie", 2f, 2f);
        InvokeRepeating("SpawnFastZombie", 5f, 5f);
        InvokeRepeating("SpawnGhostZombie", 10f, 10f);
    }

    void SpawnSimpleZombie()
    {
        portals[Random.Range(0, portals.Length)].Spawn(prefabSimpleZombie);
    }

    void SpawnFastZombie()
    {
        portals[Random.Range(0, portals.Length)].Spawn(prefabFastZombie);
    }

    void SpawnGhostZombie()
    {
        portals[Random.Range(0, portals.Length)].Spawn(prefabGhostZombie);
    }

    // Update is called once per frame
    void Update () {
		
	}

    
}
