using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastZombie :  Zombie{

    new private static int life = 2;
    new private static int demage = 2;
    new private static float speed = 3f;

    protected override void CreateZombie()
    {
        CreateZombieTypeInfo(life, demage, speed);
    }
}
