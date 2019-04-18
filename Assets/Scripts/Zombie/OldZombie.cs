using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldZombie : Zombie
{
    public EnemyBullet bullet;

    protected override void CreateZombie()
    {
        CreateZombieTypeInfo(2, 0, 2f);
        InvokeRepeating("Shoot", 1f, 1f);
    }

    void Shoot()
    {
        Instantiate(bullet, this.transform.position, Quaternion.identity).CreateBullet(new Vector2(0f, 0f), false);
    }

    protected override void OnTriggerEnter2D(Collider2D collider2D)
    {
        //base.OnTriggerEnter2D(collider2D);
    }

    protected override void OnTriggerStay2D(Collider2D collider2D)
    {
        //base.OnTriggerStay2D(collider2D);
    }
}
