using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon {

    void Start()
    {
        shotsAmount = 1;
        reloadTime = 1;
        SetAmmo(72, 12);
    }


    public override void Fire()
    {
        AudioSource.PlayClipAtPoint(gunfire, this.transform.position);
        Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(this, new Vector2(0f, 0f), false);
        AmmoChange(-shotsAmount);
    }



}
