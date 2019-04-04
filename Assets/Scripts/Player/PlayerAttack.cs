using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {

    public Bullet prefabSimpleBullet, prefabHeavyBullet;

    private int ammo = 10;
    private int ammoMax;
    private Text ammoText;
    private bool reloading = false;

    private AudioSource reloadAudioSource;
    public AudioClip gunfire;


    // Use this for initialization
    void Start () {
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

    void AmmoChange(int ammoChange)
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
                if (ammo >= SimpleBullet.ammoRequired) Fire(prefabSimpleBullet);
                else WaitBeforeReloadAll();
            }

            if (Input.GetMouseButtonDown(1))
            {
                if (ammo >= HeavyBullet.ammoRequired) Fire(prefabHeavyBullet);
                else WaitBeforeReloadAll();
            }
        }
    }

    void Fire(Bullet bullet)
    {
            AudioSource.PlayClipAtPoint(gunfire, this.transform.position);
            Instantiate(bullet, this.transform.position, transform.rotation);
            AmmoChange(-bullet.GetAmmoRequired());
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
