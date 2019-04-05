using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : Bullet {

    new static int demage = 1;
    new static float speed = 12f;
    public new static int ammoRequired = 1;

    public override void CreateBullet(Vector2 range, bool random)
    {
        CreateBulletTypeInfo(demage, speed, ammoRequired, range, random);
    }

    public override int GetAmmoRequired()
    {
        return ammoRequired;
    }
}
