using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon {

    void Start()
    {
        weaponName = "Shotgun";
        cooldownTime = 1f;
        ammoOnStack = 12;
        shotsAmount = 3;
        reloadTime = 1.5f;
        rangeRatio = 0.35f;
        SetAmmo(48, 12);
    }

    public override void CmdFire()
    {
        if (!onCoolddown)
        {
            AudioSource.PlayClipAtPoint(gunfire, this.transform.position);
            Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(this, new Vector2(0f, 0f), false);
            Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(this, new Vector2(rangeRatio, rangeRatio), false);
            Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(this, new Vector2(-rangeRatio, -rangeRatio), false);
            AmmoChange(-shotsAmount);
            Cooldwon();
        }        
        
    }

}
