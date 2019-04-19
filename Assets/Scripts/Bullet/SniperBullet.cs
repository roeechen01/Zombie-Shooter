using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBullet : Bullet
{
    public override void CreateBullet(Weapon weapon, Vector2 range, bool random)
    {
        CreateBulletTypeInfo(weapon, 5, 16f, range, random, 5);
    }
}
