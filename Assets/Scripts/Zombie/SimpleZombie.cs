using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleZombie : Zombie {

    protected override void CreateZombie()
    {
        CreateZombieTypeInfo(3, 10, 2f);
    }
}
