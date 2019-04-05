using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : Bullet {

    new static int demage = 1;
    new static float speed = 12f;
    public new static int ammoRequired = 1;

    void Start()
    {
        CreateBulletTypeInfo(demage, speed, ammoRequired, new Vector2(1, 1));
    }

    public override int GetAmmoRequired()
    {
        return ammoRequired;
    }
}
