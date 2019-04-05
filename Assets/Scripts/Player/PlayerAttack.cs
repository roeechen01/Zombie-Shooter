using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {

    public Bullet prefabSimpleBullet, prefabHeavyBullet;
    private Gun gun;

    private int ammo = 10;
    private int ammoMax;
    private Text ammoText;
    private bool reloading = false;

    private AudioSource reloadAudioSource;


    // Use this for initialization
    void Start () {
        gun = GetComponent<Gun>();
        gameObject.AddComponent<PlayerController>();
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

    public void AmmoChange(int ammoChange)
    {
        ammo += ammoChange;
        ammoText.text = "AMMO: " + ammo;
    }

    void Reload()
    {
        if(ammo < ammoMax)
            AmmoChange(1);
    }

    void FireCheck()
    {
        if (!reloading)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (ammo >= SimpleBullet.ammoRequired) gun.Fire(prefabSimpleBullet);
                else WaitBeforeReloadAll();
            }

            if (Input.GetMouseButtonDown(1))
            {
                if (ammo >= HeavyBullet.ammoRequired) gun.Fire(prefabHeavyBullet);
                else WaitBeforeReloadAll();
            }
        }
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
        ammoText.text = "Reloading...";
        PlayReloadClip();
        Wait("ReloadAll", 1);
    }
}
