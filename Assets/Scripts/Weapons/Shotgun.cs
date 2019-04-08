using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon {

    void Start()
    {
        cooldownTime = 1f;
        ammoOnStack = 12;
        shotsNumber = 3;
        reloadTime = 2;
        rangeRatio = 0.35f;
        SetAmmo(36, 12);
    }

    public override void Fire()
    {
        if (!onCoolddown)
        {
            AudioSource.PlayClipAtPoint(gunfire, this.transform.position);
            Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(new Vector2(0f, 0f), false);
            Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(new Vector2(rangeRatio, rangeRatio), false);
            Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(new Vector2(-rangeRatio, -rangeRatio), false);
            AmmoChange(-GetAmmoRequired());
            Cooldwon();
        }        
        
    }

}
