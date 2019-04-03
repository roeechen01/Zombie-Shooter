using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBullet : Bullet {

    void Start()
    {
        CreateBulletTypeInfo(2, 8f);
    }
}
