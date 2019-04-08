using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBullet : Bullet {

    new static int demage = 3;
    new static float speed = 8f;

    public override void CreateBullet(Weapon weapon, Vector2 range, bool random)
    {
        CreateBulletTypeInfo(weapon ,demage, speed, range, random);
    }
}
