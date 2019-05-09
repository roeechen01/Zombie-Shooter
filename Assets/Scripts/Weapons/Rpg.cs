using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rpg : Weapon
{
    void Start()
    {
        weaponName = "Rpg";
        shotsAmount = 1;
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
            Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y, 0.5f), transform.rotation).CreateBullet(this ,new Vector2(0.3f, 0.3f), true);
            AmmoChange(-shotsAmount);
            Cooldwon();
        }

    }

    public AudioSource GetAudioSource()
    {
        return this.GetGunFireAudioSource();
    }
}
