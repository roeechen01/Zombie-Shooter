using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesManager : MonoBehaviour
{
    public Text waveText;
    private ZombieSpawner zombieSpawner;
    private int wave = 0;
    public bool noMore = false;

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

    bool SetWave()
    {
        switch (wave)
        {
            case 1:
                zombieSpawner.ResetSpawn();
                zombieSpawner.InvokeRepeating("SpawnSimpleZombie", 1f, 1f);
                zombieSpawner.InvokeRepeating("SpawnFastZombie", 0f, 5f);
                zombieSpawner.simpleCounter = 10;
                zombieSpawner.fastCounter = 5;
                WaitForNextWave(25);
                return true;
            case 2:
                zombieSpawner.ResetSpawn();
                zombieSpawner.InvokeRepeating("SpawnSimpleZombie", 1f, 1f);
                zombieSpawner.InvokeRepeating("SpawnRunnerZombie", 2f, 2f);
                zombieSpawner.InvokeRepeating("SpawnFastZombie", 0f, 5f);
                zombieSpawner.simpleCounter = 20;
                zombieSpawner.fastCounter = 5;
                zombieSpawner.runnerCounter = 5;

                WaitForNextWave(35);
                return true;
            case 3:
                zombieSpawner.ResetSpawn();
                zombieSpawner.InvokeRepeating("SpawnSimpleZombie", 1f, 1f);
                zombieSpawner.InvokeRepeating("SpawnRunnerZombie", 2f, 2f);
                zombieSpawner.InvokeRepeating("SpawnFastZombie", 2f, 2f);
                zombieSpawner.InvokeRepeating("SpawnGhostZombie", 0f, 5f);
                zombieSpawner.simpleCounter = 20;
                zombieSpawner.runnerCounter = 10;
                zombieSpawner.fastCounter = 10;
                zombieSpawner.ghostCounter = 5;
                WaitForNextWave(45);
                return true;
            case 4:
                zombieSpawner.ResetSpawn();
                zombieSpawner.InvokeRepeating("SpawnSimpleZombie", 1f, 1f);
                zombieSpawner.InvokeRepeating("SpawnFastZombie", 2f, 2f);
                zombieSpawner.InvokeRepeating("SpawnGhostZombie", 5f, 3f);
                zombieSpawner.simpleCounter = 30;
                zombieSpawner.fastCounter = 20;
                zombieSpawner.ghostCounter = 10;
                WaitForNextWave(60);
                return true;
            case 5:
                zombieSpawner.ResetSpawn();
                zombieSpawner.InvokeRepeating("SpawnSimpleZombie", 1f, 1f);
                zombieSpawner.InvokeRepeating("SpawnFastZombie", 1f, 1f);
                zombieSpawner.InvokeRepeating("SpawnRunnerZombie", 2f, 2f);
                zombieSpawner.InvokeRepeating("SpawnGhostZombie", 5f, 3f);
                zombieSpawner.InvokeRepeating("SpawnKnifeBossZombie", 5f, 10f);
                zombieSpawner.simpleCounter = 10;
                zombieSpawner.fastCounter = 20;
                zombieSpawner.runnerCounter = 10;
                zombieSpawner.ghostCounter = 10;
                zombieSpawner.knifeBossCounter = 1;
                WaitForNextWave(60);
                return true;
            case 6:
                zombieSpawner.ResetSpawn();
                zombieSpawner.InvokeRepeating("SpawnIceZombie", 0.5f, 0.75f);
                zombieSpawner.InvokeRepeating("SpawnFastZombie", 1f, 1f);
                zombieSpawner.InvokeRepeating("SpawnRunnerZombie", 2f, 2f);
                zombieSpawner.InvokeRepeating("SpawnGhostZombie", 5f, 3f);
                zombieSpawner.iceCounter = 12;
                zombieSpawner.fastCounter = 15;
                zombieSpawner.runnerCounter = 15;
                zombieSpawner.ghostCounter = 12;
                WaitForNextWave(60);
                return true;
            case 7:
                zombieSpawner.ResetSpawn();
                zombieSpawner.InvokeRepeating("SpawnFastZombie", 1f, 1f);
                zombieSpawner.InvokeRepeating("SpawnIceZombie", 0.5f, 0.75f);
                zombieSpawner.InvokeRepeating("SpawnOldZombie", 0f, 5f);
                zombieSpawner.InvokeRepeating("SpawnRunnerZombie", 1f, 1f);
                zombieSpawner.InvokeRepeating("SpawnGhostZombie", 5f, 3f);
                zombieSpawner.fastCounter = 15;
                zombieSpawner.iceCounter = 15;
                zombieSpawner.oldCounter = 5;
                zombieSpawner.runnerCounter = 15;
                zombieSpawner.ghostCounter = 8;
                noMore = true;
                return true;
            default:
                waveText.text = "YOU WON";
                return false;
        }
    }

    public void Win()
    {
        waveText.text = "YOU WON";
    }
}
