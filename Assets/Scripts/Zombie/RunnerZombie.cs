using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerZombie : Zombie
{
    protected override void CreateZombie()
    {
        CreateZombieTypeInfo(1, 15, 3f);
    }

    new void Start()
    {
        base.Start();
        SetVelocity();
    }

    protected override void Rotaion()
    {
        var angle = Mathf.Atan2(rigidBody2d.velocity.y, rigidBody2d.velocity.x) * Mathf.Rad2Deg;
        rigidBody2d.MoveRotation(angle);
    }

    protected override void SetVelocity()
    {
        rigidBody2d.velocity = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100));
        rigidBody2d.velocity = new Vector2(rigidBody2d.velocity.x, rigidBody2d.velocity.x + Random.Range(-rigidBody2d.velocity.x / 3, rigidBody2d.velocity.x / 3));
        SetZombieSpeed();

    }

    protected override void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag.Equals("Player") && player.body == collider2D)
        {
            SpriteRenderer sr = FindObjectOfType<PlayerAttack>().GetComponent<SpriteRenderer>();
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.2f);
            DemagingPlayer();
        }
        if (collider2D.gameObject.tag.Equals("Wall"))
        {
            if (collider2D.name.Equals("side wall"))
            {
                rigidBody2d.velocity = new Vector2(-rigidBody2d.velocity.x, rigidBody2d.velocity.y);
            }
            else
            {
                rigidBody2d.velocity = new Vector2(rigidBody2d.velocity.x, -rigidBody2d.velocity.y);
            }
            SetZombieSpeed();
        }

        Bullet bullet = collider2D.gameObject.GetComponent<Bullet>();
        if (bullet && canHit)
        {
            Blood tempBlood = Instantiate(blood, new Vector3(bullet.transform.position.x, bullet.transform.position.y, -1f), Quaternion.identity);
            bloods.Add(tempBlood);
            tempBlood.SetZombie(this);
        }
    }

    protected override void OnTriggerStay2D(Collider2D collider2D)
    {
        
    }

    new void Update()
    {
        Rotaion();
    }
}
