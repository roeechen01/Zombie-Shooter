using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {
    public SimpleZombie prefabSimpleZombie;
    public FastZombie prefabFastZombie;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnZombie", 0f, 5f);
    }

    void SpawnZombie()
    {
        int rnd = Random.Range(1, 5);
        switch (rnd)
        {
            case 1:
                if(Random.Range(1,3) == 1)
                    Instantiate(prefabSimpleZombie, new Vector3(Random.Range(-20f, 20f),-21f,0f), Quaternion.identity);
                else Instantiate(prefabFastZombie, new Vector3(Random.Range(-20f, 20f), -21f, 0f), Quaternion.identity);
                break;
            case 2:
                if (Random.Range(1, 3) == 1)
                    Instantiate(prefabSimpleZombie, new Vector3(Random.Range(-20f, 20f), 16.5f, 0f), Quaternion.identity);
                else Instantiate(prefabFastZombie, new Vector3(Random.Range(-20f, 20f), 16.5f, 0f), Quaternion.identity);
                break;
            case 3:
                if (Random.Range(1, 3) == 1)
                    Instantiate(prefabSimpleZombie, new Vector3(20f, Random.Range(16.5f, -20f), 0f), Quaternion.identity);
                else Instantiate(prefabFastZombie, new Vector3(20f, Random.Range(16.5f, -20f), 0f), Quaternion.identity);
                break;
            case 4:
                if (Random.Range(1, 3) == 1)
                    Instantiate(prefabSimpleZombie, new Vector3(-20f, Random.Range(16.5f, -20f), 0f), Quaternion.identity);
                else Instantiate(prefabFastZombie, new Vector3(-20f, Random.Range(16.5f, -20f), 0f), Quaternion.identity);
                break;
        }

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
