using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesManager : MonoBehaviour
{
    public Text waveText;
    private ZombieSpawner zombieSpawner;
    private int wave = 4;

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

    void WaitForNextWave (float seconds)
    {
        Invoke("NextWave", seconds);
    }

    void SetWave()
    {
        switch (wave)
        {
            case 1:
                zombieSpawner.ResetSpawn();
                zombieSpawner.InvokeRepeating("SpawnSimpleZombie", 1f, 1f);
                zombieSpawner.simpleCounter = 10;
                WaitForNextWave(25);
                break;
            case 2:
                zombieSpawner.ResetSpawn();
                zombieSpawner.InvokeRepeating("SpawnSimpleZombie", 1f, 1f);
                zombieSpawner.InvokeRepeating("SpawnFastZombie", 0f, 5f);
                zombieSpawner.simpleCounter = 20;
                zombieSpawner.fastCounter = 5;
                WaitForNextWave(35);
                break;
            case 3:
                zombieSpawner.ResetSpawn();
                zombieSpawner.InvokeRepeating("SpawnSimpleZombie", 1f, 1f);
                zombieSpawner.InvokeRepeating("SpawnFastZombie", 2f, 2f);
                zombieSpawner.InvokeRepeating("SpawnGhostZombie", 0f, 5f);
                zombieSpawner.simpleCounter = 20;
                zombieSpawner.fastCounter = 10;
                zombieSpawner.ghostCounter = 5;
                WaitForNextWave(45);
                break;
            case 4:
                zombieSpawner.ResetSpawn();
                zombieSpawner.InvokeRepeating("SpawnSimpleZombie", 1f, 1f);
                zombieSpawner.InvokeRepeating("SpawnFastZombie", 2f, 2f);
                zombieSpawner.InvokeRepeating("SpawnGhostZombie", 5f, 3f);
                zombieSpawner.simpleCounter = 30;
                zombieSpawner.fastCounter = 20;
                zombieSpawner.ghostCounter = 10;
                WaitForNextWave(60);
                break;
            case 5:
                zombieSpawner.ResetSpawn();
                zombieSpawner.InvokeRepeating("SpawnFastZombie", 1f, 1f);
                zombieSpawner.InvokeRepeating("SpawnGhostZombie", 5f, 3f);
                zombieSpawner.InvokeRepeating("SpawnKnifeBossZombie", 5f, 10f);
                zombieSpawner.fastCounter = 0;
                zombieSpawner.ghostCounter = 0;
                zombieSpawner.knifeBossCounter = 1;
                WaitForNextWave(100);
                break;
            default:
                waveText.text = "YOU WON";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
