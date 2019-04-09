using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastZombie :  Zombie{

    protected override void CreateZombie()
    {
        CreateZombieTypeInfo(2, 2, 3f);
    }
}
