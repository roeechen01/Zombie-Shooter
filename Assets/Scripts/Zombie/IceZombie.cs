using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceZombie : Zombie
{
    protected override void CreateZombie()
    {
        CreateZombieTypeInfo(1, 0, 3.5f);
    }

    protected override void DemagingPlayer()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        player.Freeze(2);
    }
}
