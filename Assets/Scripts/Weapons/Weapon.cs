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
    public Sprite sprite;
    private Text ammoText;

    protected bool onCoolddown = false;
    protected float cooldownTime;
    public bool reloading = false;
    protected int reloadTime;

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
                ammoOnStack = ammoLeft;
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

    public void SetUpWeapon()
    {
        this.ammoLeft = this.ammoMax;
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
