using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sniper : Weapon
{
    public SniperLaser laser;
    void Start()
    {
        weaponName = "Sniper";
        cooldownTime = 1f;
        ammoOnStack = 4;
        shotsAmount = 1;
        reloadTime = 2;
        rangeRatio = 0f;
        SetAmmo(16, 4);
        laser = Instantiate(laser, this.transform.position, Quaternion.identity);
    }

    public override void Fire()
    {
        if (!onCoolddown)
        {
            AudioSource.PlayClipAtPoint(gunfire, this.transform.position);
            Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(this, new Vector2(0f, 0f), false);
            AmmoChange(-shotsAmount);
            Cooldwon();
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Game"))
        {
            laser.transform.position = this.transform.position;
            if (playerAttack && playerAttack.GetWeapon() == this)
            {
                laser.Visible();
                laser.transform.rotation = playerAttack.transform.rotation;

            }
            else laser.Invisible();
        }
        
    }
}
