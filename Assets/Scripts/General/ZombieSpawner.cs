using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {
    public SimpleZombie prefabSimpleZombie;
    public FastZombie prefabFastZombie;
    public GhostZombie prefabGhostZombie;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnSimpleZombie", 1f, 1f);
        InvokeRepeating("SpawnFastZombie", 3f, 3f);
        InvokeRepeating("SpawnGhostZombie", 5f, 5f);
    }

    void SpawnSimpleZombie()
    {
        switch (Random.Range(1, 5))
        {
            case 1:
                Instantiate(prefabSimpleZombie, new Vector3(Random.Range(-20f, 20f),-21f,0f), Quaternion.identity);
                break;
            case 2:
                Instantiate(prefabSimpleZombie, new Vector3(Random.Range(-20f, 20f), 16.5f, 0f), Quaternion.identity);
                break;
            case 3:
                Instantiate(prefabSimpleZombie, new Vector3(20f, Random.Range(16.5f, -20f), 0f), Quaternion.identity);
                break;
            case 4:
                Instantiate(prefabSimpleZombie, new Vector3(-20f, Random.Range(16.5f, -20f), 0f), Quaternion.identity);
                break;
        }

        
    }

    void SpawnFastZombie()
    {
        switch (Random.Range(1, 5))
        {
            case 1:
                Instantiate(prefabFastZombie, new Vector3(Random.Range(-20f, 20f), -21f, 0f), Quaternion.identity);
                break;
            case 2:
                Instantiate(prefabFastZombie, new Vector3(Random.Range(-20f, 20f), 16.5f, 0f), Quaternion.identity);
                break;
            case 3:
                Instantiate(prefabFastZombie, new Vector3(20f, Random.Range(16.5f, -20f), 0f), Quaternion.identity);
                break;
            case 4:
                Instantiate(prefabFastZombie, new Vector3(-20f, Random.Range(16.5f, -20f), 0f), Quaternion.identity);
                break;
        }
    }

    void SpawnGhostZombie()
    {
        switch (Random.Range(1, 5))
        {
            case 1:
                Instantiate(prefabGhostZombie, new Vector3(Random.Range(-20f, 20f), -21f, 0f), Quaternion.identity);
                break;
            case 2:
                Instantiate(prefabGhostZombie, new Vector3(Random.Range(-20f, 20f), 16.5f, 0f), Quaternion.identity);
                break;
            case 3:
                Instantiate(prefabGhostZombie, new Vector3(20f, Random.Range(16.5f, -20f), 0f), Quaternion.identity);
                break;
            case 4:
                Instantiate(prefabGhostZombie, new Vector3(-20f, Random.Range(16.5f, -20f), 0f), Quaternion.identity);
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
