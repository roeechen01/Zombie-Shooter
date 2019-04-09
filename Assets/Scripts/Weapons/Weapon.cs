using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {

    public Bullet bullet;
    protected PlayerAttack playerAttack;
    public AudioClip gunfire;
    protected int shotsNumber;
    public AudioClip reloadClip;
    private bool playing;
    public Sprite sprite;
    private Text ammoText;

    protected bool onCoolddown = false;
    protected float cooldownTime;
    bool reloading = false;
    protected int reloadTime;
    protected float rangeRatio;

    public bool IsReloading()
    {
        return this.reloading;
    }

    public AudioSource GetGunFireAudioSource()
    {
        return this.playerAttack.gunFireAudioSource;
    }


    protected int ammoOnStack, stackMax, ammoMax, ammoLeft;

    public bool CanFire()
    {
        return ammoOnStack >= shotsNumber;
    }

    protected void CooldownOver()
    {
        onCoolddown = false;
    }

    protected void Cooldwon()
    {
        onCoolddown = true;
        Invoke("CooldownOver", cooldownTime);
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

    void UpdateAmmoText()
    {
        if (reloading)
            ammoText.text = "Reloading...";
        else ammoText.text = ammoOnStack + "/" + ammoLeft;
    }

    public void WaitBeforeReloadAll()
    {
        if (ammoOnStack != stackMax && ammoLeft > 0)
        {

            reloading = true;
            UpdateAmmoText();
            PlayReloadClip();
            Invoke("ReloadAll", reloadTime);
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
            if (bulletsToReload <= ammoLeft)
            {
                ammoOnStack = stackMax;
                ammoLeft -= bulletsToReload;
            }
            else
            {
                ammoOnStack += ammoLeft;
                ammoLeft = 0;
            }
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

    public void SetUpWeapon(bool alreadyWeapon)
    {
        //bool active = this.Equals(playerAttack.GetWeapon());
        //if (!active && (this.ammoLeft != ammoMax - this.stackMax || this.ammoOnStack != this.stackMax))
        //{
        //    this.ammoLeft = this.ammoMax;
        //    this.ammoOnStack = 0;
        //}
        //else
        //    this.ammoLeft = ammoMax - this.stackMax;
        //if(active)
        //    UpdateAmmoText();
        if (alreadyWeapon)
        {
            this.ammoLeft = this.ammoMax - this.stackMax;
            UpdateAmmoText();
        }
        else
        {
            SetAmmo(ammoMax, stackMax);
            playerAttack.PickupWeapon(this);
        }
    }

    void PlayReloadClip()
    {
        if (!playing)
        {
            this.playing = true;
            AudioSource.PlayClipAtPoint(reloadClip, this.transform.position);
            Invoke("SetNotPlaying", reloadClip.length);
        }
    }

    void SetNotPlaying()
    {
        this.playing = false;
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
