using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {

    protected PlayerAttack playerAttack;
    public AudioClip gunfire;
    protected Bullet bullet;
    protected int shotsNumber;
    public AudioClip reloadClip;

    public bool reloading = false;
    protected int reloadTime;

    protected int ammo;
    private int ammoMax;
    private Text ammoText;

    public bool CanFire()
    {
        return ammo >= shotsNumber;
    }

    public virtual void Fire()
    {

    }

    public void SetPlayerAttack(PlayerAttack playerAttack)
    {
        this.playerAttack = playerAttack;
    }

    protected int GetAmmoRequired()
    {
        return bullet.GetAmmoRequired() * shotsNumber;
    }


    void Wait(string methodName, float seconds)
    {
        Invoke(methodName, seconds);
    }

    public void WaitBeforeReloadAll()
    {
        if (ammo != ammoMax)
        {

            reloading = true;
            ammoText.text = "Reloading...";
            PlayReloadClip();
            Wait("ReloadAll", reloadTime);
        }

        else
        {
            ammoText.text = "AMMO: " + ammo;
        }
    }

    void ReloadAll()
    {
        if (ammo != ammoMax)
        {
            ammo = ammoMax;
            reloading = false;
            ammoText.text = "AMMO: " + ammo;
        }

    }

    void Start()
    {
        ammoText = FindObjectOfType<Text>();
        ammoMax = ammo;
        ammoText.text = "AMMO: " + ammo;
    }
    void Update()
    {

        
    }
    void PlayReloadClip()
    {
        AudioSource.PlayClipAtPoint(reloadClip, this.transform.position);
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
        if (ammo < ammoMax)
            AmmoChange(1);
    }


}
