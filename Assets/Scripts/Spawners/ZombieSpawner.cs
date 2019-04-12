using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {
    private WavesManager wavesManager;

    public SimpleZombie prefabSimpleZombie;
    public FastZombie prefabFastZombie;
    public GhostZombie prefabGhostZombie;
    Portal[] portals;

    public int simpleCounter = 0;
    public int fastCounter = 0;
    public int ghostCounter = 0;

    // Use this for initialization
    void Start () {
        wavesManager = FindObjectOfType<WavesManager>();
        portals = FindObjectsOfType<Portal>();
        InvokeRepeating("SpawnSimpleZombie", 1f, 1f);
        InvokeRepeating("SpawnFastZombie", 2f, 2f);
        InvokeRepeating("SpawnGhostZombie", 10f, 10f);
    }

    void SpawnSimpleZombie()
    {
        if(simpleCounter > 0)
        {
            portals[Random.Range(0, portals.Length)].Spawn(prefabSimpleZombie);
            simpleCounter--;
        }
    }

    void SpawnFastZombie()
    {
        if (fastCounter > 0)
        {
            portals[Random.Range(0, portals.Length)].Spawn(prefabFastZombie);
            fastCounter--;
        }
    }

    void SpawnGhostZombie()
    {
        if (ghostCounter > 0)
        {
            portals[Random.Range(0, portals.Length)].Spawn(prefabGhostZombie);
            ghostCounter--;
        }
    }

    public void CheckIfFinishedWave()
    {
        if (simpleCounter <= 0 && fastCounter <= 0 && ghostCounter <= 0 && Zombie.aliveZombies.Count <= 0)
            wavesManager.NextWave();
    }

    // Update is called once per frame
    void Update () {
        
	}

    
}
