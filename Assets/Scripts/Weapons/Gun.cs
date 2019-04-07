using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon {

    public SimpleBullet simpleBullet;

    void Start()
    {
        shotsNumber = 1;
        reloadTime = 1;
        bullet = simpleBullet;
        SetAmmo(50, 10);
    }


    public override void Fire()
    {
        AudioSource.PlayClipAtPoint(gunfire, this.transform.position);
        Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(new Vector2(0f, 0f), false);
        AmmoChange(-GetAmmoRequired());
    }



}
