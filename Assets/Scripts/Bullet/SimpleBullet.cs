using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : Bullet {


    public override void CreateBullet(Weapon weapon, Vector2 range, bool random)
    {
        CreateBulletTypeInfo(weapon ,1, 12f, range, random, 1);
    }

    

}
