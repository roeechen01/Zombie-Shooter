using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesManager : MonoBehaviour
{
    public Text waveText;
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
        UpdateText();
        SetWave();
    }

    void UpdateText()
    {
        waveText.text = "Wave " + this.wave;
        Invoke("EmptyText", 1f);
    }

    void EmptyText()
    {
        waveText.text = "";
    }

    void SetWave()
    {
        switch (wave)
        {
            case 1:
                zombieSpawner.ResetSpawn();
                zombieSpawner.InvokeRepeating("SpawnSimpleZombie", 1f, 1f);
                zombieSpawner.simpleCounter = 10;
                break;
            case 2:
                zombieSpawner.ResetSpawn();
                zombieSpawner.InvokeRepeating("SpawnSimpleZombie", 1f, 1f);
                zombieSpawner.InvokeRepeating("SpawnFastZombie", 0f, 5f);
                zombieSpawner.simpleCounter = 10;
                zombieSpawner.fastCounter = 5;
                break;
            case 3:
                zombieSpawner.ResetSpawn();
                zombieSpawner.InvokeRepeating("SpawnSimpleZombie", 1f, 1f);
                zombieSpawner.InvokeRepeating("SpawnFastZombie", 2f, 2f);
                zombieSpawner.InvokeRepeating("SpawnGhostZombie", 0f, 5f);
                zombieSpawner.simpleCounter = 20;
                zombieSpawner.fastCounter = 10;
                zombieSpawner.ghostCounter = 5;
                break;
            case 4:
                zombieSpawner.ResetSpawn();
                zombieSpawner.InvokeRepeating("SpawnSimpleZombie", 1f, 1f);
                zombieSpawner.InvokeRepeating("SpawnFastZombie", 2f, 2f);
                zombieSpawner.InvokeRepeating("SpawnGhostZombie", 5f, 3f);
                zombieSpawner.simpleCounter = 30;
                zombieSpawner.fastCounter = 20;
                zombieSpawner.ghostCounter = 10;
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
