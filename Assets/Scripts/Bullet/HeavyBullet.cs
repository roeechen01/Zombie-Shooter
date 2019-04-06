using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBullet : Bullet {

    new static int demage = 2;
    new static float speed = 8f;
    public new static int ammoRequired = 2;

    void Start()
    {
    }

    public override void CreateBullet(Vector2 range, bool random)
    {
        CreateBulletTypeInfo(demage, speed, ammoRequired, range, random);
    }

    public override int GetAmmoRequired()
    {
        return ammoRequired;
    }
}
