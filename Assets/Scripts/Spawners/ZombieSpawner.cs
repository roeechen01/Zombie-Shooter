using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

    public SimpleZombie prefabSimpleZombie;
    public FastZombie prefabFastZombie;
    public GhostZombie prefabGhostZombie;
    public KnifeBossZombie prefabKnifeBossZombie;
    public RunnerZombie prefabRunnerZombie;
    Portal[] portals;

    public int simpleCounter = 0;
    public int fastCounter = 0;
    public int ghostCounter = 0;
    public int runnerCounter = 0;
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

    void SpawnRunnerZombie()
    {
        if (runnerCounter > 0)
        {
            portals[Random.Range(0, portals.Length)].Spawn(prefabRunnerZombie);
            runnerCounter--;
        }
    }

    void SpawnKnifeBossZombie()
    {
        if (knifeBossCounter > 0 && FindObjectsOfType<Boss>().Length == 0)
        {
            portals[Random.Range(0, portals.Length)].Spawn(prefabKnifeBossZombie);
            knifeBossCounter--;
        }
    }

    public void ResetSpawn()
    {
        simpleCounter = 0;
        fastCounter = 0;
        ghostCounter = 0;
        runnerCounter = 0;
        knifeBossCounter = 0;
        CancelInvoke();
    }

    public bool FinishedWaveCheck()
    {
        return simpleCounter == 0 && fastCounter == 0 && ghostCounter == 0 && runnerCounter == 0 && knifeBossCounter == 0 && FindObjectsOfType<Zombie>().Length == 0;
    }

    // Update is called once per frame
    void Update () {
        
	}

    
}
