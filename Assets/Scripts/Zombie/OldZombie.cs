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
        Instantiate(bullet, this.transform.position, Quaternion.identity).CreateBullet(new Vector2(0.3f, 0.3f), true);
    }

    protected override void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag.Equals("Player") && player.body == collider2D)
        {
            rigidBody2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    protected override void OnTriggerStay2D(Collider2D collider2D)
    {
    }
}
