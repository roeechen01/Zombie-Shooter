using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {

    public Bullet prefabBullet;
    private int ammo = 10;
    private int ammoMax;
    private Text ammoText;
    private bool reloading = false;

    private AudioSource reloadAudioSource;
    public AudioClip gunfire;


    // Use this for initialization
    void Start () {
        reloadAudioSource = GetComponent<AudioSource>();
        ammoText = FindObjectOfType<Text>();
        ammoMax = ammo;
        ammoText.text = "AMMO: " + ammo;
    }

    void PlayReloadClip()
    {
        if (!reloadAudioSource.isPlaying)
            reloadAudioSource.Play();
    }

    void ReloadRepeat()
    {
        InvokeRepeating("Reload", 0f, 1f);
    }

    void AmmoChange(int ammoChange)
    {
        ammo += ammoChange;
        ammoText.text = "AMMO: " + ammo;
    }

    void Reload()
    {
        if(ammo<ammoMax)
            AmmoChange(1);
    }

    void FireCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!reloading)
            {
                if(ammo > 0) Fire();
                else WaitBeforeReloadAll();
            }    
        }
    }

    void Fire()
    {
        AudioSource.PlayClipAtPoint(gunfire, this.transform.position);
        Instantiate(prefabBullet, this.transform.position, transform.rotation);
        AmmoChange(-1);
    }

    // Update is called once per frame
    void Update () {
        FireCheck();
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (ammo != ammoMax)
                WaitBeforeReloadAll();
        }
    }

    void ReloadAll()
    {
        if(ammo != ammoMax)
        {
            ammo = ammoMax;
            reloading = false;
            ammoText.text = "AMMO: " + ammo;
        }
        
    }

    void Wait(string methodName ,float seconds)
    {
        Invoke(methodName, seconds);
    }

    void WaitBeforeReloadAll()
    {
        reloading = true;
        PlayReloadClip();
        Wait("ReloadAll", 1);
    }
}
