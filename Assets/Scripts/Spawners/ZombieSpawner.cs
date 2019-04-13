using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

    public SimpleZombie prefabSimpleZombie;
    public FastZombie prefabFastZombie;
    public GhostZombie prefabGhostZombie;
    public KnifeBossZombie prefabKnifeBossZombie;
    Portal[] portals;

    public int simpleCounter = 0;
    public int fastCounter = 0;
    public int ghostCounter = 0;
    public int knifeBossCounter = 0;

    // Use this for initialization
    void Start () {
        portals = FindObjectsOfType<Portal>();
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

    void SpawnKnifeBossZombie()
    {
        if (knifeBossCounter > 0 && FindObjectsOfType<KnifeBossZombie>().Length == 0)
        {
            portals[Random.Range(0, portals.Length)].Spawn(prefabKnifeBossZombie);
            knifeBossCounter--;
        }
    }

    //public void CheckIfFinishedWave()
    //{
    //    if (simpleCounter <= 0 && fastCounter <= 0 && ghostCounter <= 0 && Zombie.aliveZombies.Count <= 0)
    //        wavesManager.NextWave();
    //}

    public void ResetSpawn()
    {
        simpleCounter = 0;
        fastCounter = 0;
        ghostCounter = 0;
        CancelInvoke();
    }

    // Update is called once per frame
    void Update () {
        
	}

    
}
