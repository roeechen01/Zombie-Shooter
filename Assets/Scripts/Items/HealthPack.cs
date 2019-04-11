using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : Item
{
    protected override void Ability()
    {
        player.AddLife(0, true);
    }

}
