using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Gun : Weapon {

    void Start()
    {
        weaponName = "Gun";
        shotsAmount = 1;
        reloadTime = 1;
        SetAmmo(72, 12);
    }

    [Command]
    public override void CmdFire()
    {
        AudioSource.PlayClipAtPoint(gunfire, this.transform.position);
        GameObject bulletPrefab = Instantiate(bullet, this.transform.position, transform.rotation).gameObject;
        bulletPrefab.GetComponent<Bullet>().CreateBullet(this, new Vector2(0f, 0f), false);
        NetworkServer.Spawn(bulletPrefab);
        AmmoChange(-shotsAmount);
    }



}
