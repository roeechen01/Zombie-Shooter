using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleZombie : Zombie {

    new private static int life = 2;
    new private static int demage = 1;
    new private static float speed = 2f;

    protected override void CreateZombie()
    {
        CreateZombieTypeInfo(life, demage, speed);
        head = GetComponent<PolygonCollider2D>();
    }




}
