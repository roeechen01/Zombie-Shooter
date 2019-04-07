using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon {

    public SimpleBullet simpleBullet;
    bool fireActive = false;


    void Start()
    {
        cooldownTime = 0.1f;
        ammoOnStack = 50;
        shotsNumber = 1;
        reloadTime = 2;
        bullet = simpleBullet;
        SetAmmo(250, 50);
    }

    public override void Fire()
    {
        fireActive = true;
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && ammoOnStack >= shotsNumber && fireActive)
        {
            if (!onCoolddown)
            {
                AudioSource.PlayClipAtPoint(gunfire, this.transform.position);
                Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(new Vector2(0.2f, 0.2f), true);
                AmmoChange(-GetAmmoRequired());
                Cooldwon();
            }
        }
        else fireActive = false;
    }
}
