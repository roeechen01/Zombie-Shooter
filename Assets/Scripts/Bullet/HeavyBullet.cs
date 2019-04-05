using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBullet : Bullet {

    new static int demage = 2;
    new static float speed = 8f;
    public new static int ammoRequired = 3;

    void Start()
    {
        CreateBulletTypeInfo(demage, speed, ammoRequired, new Vector2(0,0));
    }

    public override int GetAmmoRequired()
    {
        return ammoRequired;
    }
}
