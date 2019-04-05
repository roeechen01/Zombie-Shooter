using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {
    public Zombie prefabZombie;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnZombie", 0f, 1f);
    }

    void SpawnZombie()
    {
        int rnd = Random.Range(1, 5);
        switch (rnd)
        {
            case 1:
                Instantiate(prefabZombie, new Vector3(Random.Range(-20f, 20f),-21f,0f), Quaternion.identity);
                break;
            case 2:
                Instantiate(prefabZombie, new Vector3(Random.Range(-20f, 20f), 16.5f, 0f), Quaternion.identity);
                break;
            case 3:
                Instantiate(prefabZombie, new Vector3(20f, Random.Range(16.5f, -20f), 0f), Quaternion.identity);
                break;
            case 4:
                Instantiate(prefabZombie, new Vector3(-20f, Random.Range(16.5f, -20f), 0f), Quaternion.identity);
                break;
        }

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
