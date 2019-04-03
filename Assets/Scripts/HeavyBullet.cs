using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBullet : Bullet {

    public new static int demage = 2;
    public new static float speed = 8f;
    public new static int ammoRequired = 3;

    void Start()
    {
        CreateBulletTypeInfo(demage, speed, ammoRequired);
    }

    public override int GetAmmoRequired()
    {
        return ammoRequired;
    }
}
