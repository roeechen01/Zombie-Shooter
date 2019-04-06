using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon {

    public HeavyBullet heavyBullet;
    bool onCoolddown = false;
    
    private float ratio = 0.75f;

    void Awake()
    {
        ammo = 12;
        shotsNumber = 3;
        reloadTime = 2;
        bullet = heavyBullet;
    }

    void SetCooldown()
    {
        onCoolddown = false;
    }

    void Wait(string methodName, float seconds)
    {
        Invoke(methodName, seconds);
    }

    public override void Fire()
    {
        if (!onCoolddown)
        {
            AudioSource.PlayClipAtPoint(gunfire, this.transform.position);
            Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(new Vector2(0f, 0f), false);
            Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(new Vector2(ratio, ratio), false);
            Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(new Vector2(-ratio, -ratio), false);
            AmmoChange(-GetAmmoRequired());
            onCoolddown = true;
            Invoke("SetCooldown", 1f);
        }        
        
    }

}
