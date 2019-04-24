using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceZombie : Zombie
{
    protected override void CreateZombie()
    {
        CreateZombieTypeInfo(1, 0, 3.5f);
    }

    protected override void DemagingPlayer(PlayerAttack player)
    {
        PlayerController playerConroller = player.GetComponent<PlayerController>();
        if(playerConroller.GetComponent<PlayerAttack>().GetVulnerable())
            playerConroller.Freeze(2);
    }
}
