﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {

    protected PlayerAttack playerAttack;
    public AudioClip gunfire;
    protected Bullet bullet;
    protected int shotsNumber;
    public AudioClip reloadClip;
    public Sprite sprite;
    private Text ammoText;

    public bool reloading = false;
    protected int reloadTime;

    protected int ammoOnStack, stackMax, ammoMax, ammoLeft;

    public bool CanFire()
    {
        return ammoOnStack >= shotsNumber;
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
        return shotsNumber;
    }


    void Wait(string methodName, float seconds)
    {
        Invoke(methodName, seconds);
    }

    void UpdateAmmoText()
    {
        if (reloading)
            ammoText.text = "Reloading...";
        else ammoText.text = ammoOnStack + "/" + ammoLeft;
    }

    public void WaitBeforeReloadAll()
    {
        if (ammoOnStack != stackMax)
        {

            reloading = true;
            ammoText.text = "Reloading...";
            PlayReloadClip();
            Wait("ReloadAll", reloadTime);
        }

        else
        {
            UpdateAmmoText();
        }
    }

    void ReloadAll()
    {
        if (ammoOnStack != stackMax)
        {
                int bulletsToReload = stackMax - ammoOnStack;
                ammoOnStack = stackMax;
                ammoLeft -= bulletsToReload;
                reloading = false;
                UpdateAmmoText();
        }
    }

    void Awake()
    {
        ammoText = FindObjectOfType<Text>();
    }

   protected void SetAmmo(int ammoMax, int stackMax)
    {
        this.ammoMax = ammoMax;
        this.ammoLeft = this.ammoMax;
        this.stackMax = stackMax;
        this.ammoOnStack = this.stackMax;
        this.ammoLeft -= this.stackMax;

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
        ammoOnStack += ammoChange;
        UpdateAmmoText();
    }

    void Reload()
    {
        if (ammoOnStack < ammoMax)
            AmmoChange(1);
    }


}
