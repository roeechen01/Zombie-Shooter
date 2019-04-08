using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : Bullet {

    new static int demage = 1;
    new static float speed = 12f;

    public override void CreateBullet(Weapon weapon, Vector2 range, bool random)
    {
        CreateBulletTypeInfo(weapon ,demage, speed, range, random);
    }

}
