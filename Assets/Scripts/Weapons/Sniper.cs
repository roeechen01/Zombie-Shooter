using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Weapon
{
    public SniperLaser laser;
    void Start()
    {
        cooldownTime = 1f;
        ammoOnStack = 4;
        shotsAmount = 1;
        reloadTime = 2;
        rangeRatio = 0f;
        SetAmmo(12, 4);
        laser = Instantiate(laser, this.transform.position, Quaternion.identity);
    }

    public override void Fire()
    {
        if (!onCoolddown)
        {
            AudioSource.PlayClipAtPoint(gunfire, this.transform.position);
            Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(this, new Vector2(0f, 0f), false);
            AmmoChange(-shotsAmount);
            Cooldwon();
        }
    }

    void Update()
    {
        laser.transform.position = this.transform.position;
        if (playerAttack.GetWeapon() == this)
        {
            laser.Visible();
        }
        else laser.Invisible();
        laser.transform.rotation = playerAttack.transform.rotation;
    }
}
