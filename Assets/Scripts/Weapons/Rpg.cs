using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rpg : Weapon
{
    void Start()
    {
        shotsNumber = 1;
        reloadTime = 3;
        cooldownTime = 2f;
        SetAmmo(6, 2);
    }

    public override void Fire()
    {
        if (!onCoolddown)
        {
            GetGunFireAudioSource().clip = gunfire;
            GetGunFireAudioSource().Play();
            Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(this ,new Vector2(0.3f, 0.3f), true);
            AmmoChange(-GetAmmoRequired());
            Cooldwon();
        }

    }

    public AudioSource GetAudioSource()
    {
        return this.GetGunFireAudioSource();
    }
}
