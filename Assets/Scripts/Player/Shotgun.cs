using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon {

    public HeavyBullet heavyBullet;

    private float ratio = 0.75f;

    void Awake()
    {
        ammo = 18;
        shotsNumber = 3;
        reloadTime = 2;
        bullet = heavyBullet;
    }

    public override void Fire()
    {
        AudioSource.PlayClipAtPoint(gunfire, this.transform.position);
        Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(new Vector2(0f, 0f), false);
        Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(new Vector2(ratio, ratio), false);
        Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(new Vector2(-ratio, -ratio), false);
        AmmoChange(-GetAmmoRequired());
    }

}
