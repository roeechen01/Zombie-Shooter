using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Bullet
{
    new static int demage = 1;
    new static float speed = 6;
    public Explosion explosion;

    public override void CreateBullet(Vector2 range, bool random)
    {
        CreateBulletTypeInfo(demage, speed, range, random);
    }

    protected override void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (!collider2D.gameObject.tag.Equals("Player"))
        {
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
