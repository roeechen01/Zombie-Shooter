using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : Bullet {

    void Start()
    {
        CreateBulletTypeInfo(1, 12f);
    }
}
