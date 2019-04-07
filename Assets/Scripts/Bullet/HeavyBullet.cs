using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBullet : Bullet {

    new static int demage = 2;
    new static float speed = 8f;

    public override void CreateBullet(Vector2 range, bool random)
    {
        CreateBulletTypeInfo(demage, speed, range, random);
    }
}
