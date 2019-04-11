using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostZombie : Zombie
{
    protected override void CreateZombie()
    {
        CreateZombieTypeInfo(3, 30, 4f);
    }
}
