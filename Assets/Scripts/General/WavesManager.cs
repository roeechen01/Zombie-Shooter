using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    private ZombieSpawner zombieSpawner;
    private int wave = 0;

    // Start is called before the first frame update
    void Start()
    {
        zombieSpawner = FindObjectOfType<ZombieSpawner>();
        NextWave();
    }

    public void NextWave()
    {
        wave++;
        SetWave();
        print("next wave");
    }

    void SetWave()
    {
        switch (wave)
        {
            case 1:
                zombieSpawner.simpleCounter = 10;
                zombieSpawner.fastCounter = 0;
                zombieSpawner.ghostCounter = 0;
                break;
            case 2:
                zombieSpawner.simpleCounter = 0;
                zombieSpawner.fastCounter = 10;
                zombieSpawner.ghostCounter = 0;
                break;
            default:
                print("Finished");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
