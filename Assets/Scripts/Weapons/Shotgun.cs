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

    public override void Fire()
    {
        if (!onCoolddown)
        {
            AudioSource.PlayClipAtPoint(gunfire, this.transform.position);
            Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y, 1f), transform.rotation).CreateBullet(this, new Vector2(0f, 0f), false);
            Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y, 1f), transform.rotation).CreateBullet(this, new Vector2(rangeRatio, rangeRatio), false);
            Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y, 1f), transform.rotation).CreateBullet(this, new Vector2(-rangeRatio, -rangeRatio), false);
            AmmoChange(-shotsAmount);
            Cooldwon();
        }        
        
    }

}
