using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Bullet
{
    static int demage = 1;
    new static float speed = 6;
    public Explosion explosion;
    public Rpg rpg;

    public override void CreateBullet(Weapon weapon ,Vector2 range, bool random)
    {
        rpg = weapon.gameObject.GetComponent<Rpg>();
        CreateBulletTypeInfo(weapon, demage, speed, range, random);
    }

    protected override void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (!collider2D.gameObject.tag.Equals("Player"))
        {
            Zombie zombie = collider2D.GetComponent<Zombie>();
            if(!(zombie && !zombie.CanHit()))
            {
                if (rpg.GetAudioSource().isPlaying)
                    rpg.GetAudioSource().Stop();
                Instantiate(explosion, this.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            
        }

    }
}
