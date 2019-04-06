using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon {

    public SimpleBullet simpleBullet;
    bool fireActive = false;

    bool onCoolddown = false;

    void Awake()
    {
        ammo = 50;
        shotsNumber = 1;
        reloadTime = 2;
        bullet = simpleBullet;
    }

    void CooldownOver()
    {
        onCoolddown = false;
    }

    void Cooldwon()
    {
        onCoolddown = true;
        Invoke("CooldownOver", 0.1f);
    }

    public override void Fire()
    {
        fireActive = true;
        //while (Input.GetMouseButtonDown(0) && ammo >= shotsNumber && !onCoolddown)
        //{
        //    AudioSource.PlayClipAtPoint(gunfire, this.transform.position);
        //    Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(new Vector2(0f, 0f), false);
        //    AmmoChange(-GetAmmoRequired());
        //    Cooldwon();
        //}
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && ammo >= shotsNumber && fireActive)
        {
            if (!onCoolddown)
            {
                AudioSource.PlayClipAtPoint(gunfire, this.transform.position);
                Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(new Vector2(0f, 0f), false);
                AmmoChange(-GetAmmoRequired());
                Cooldwon();
            }
        }
        else fireActive = false;
    }
}
