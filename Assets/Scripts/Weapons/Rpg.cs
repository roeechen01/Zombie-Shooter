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
        SetAmmo(3, 1);
    }

    public override void Fire()
    {
        if (!onCoolddown)
        {
            AudioSource.PlayClipAtPoint(gunfire, this.transform.position);
            Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(new Vector2(0f, 0f), false);
            AmmoChange(-GetAmmoRequired());
            Cooldwon();
        }

    }
}
