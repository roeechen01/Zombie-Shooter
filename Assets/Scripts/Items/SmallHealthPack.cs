using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallHealthPack : Item
{
    protected override void Ability()
    {
        player.AddLife(25, false);
    }
}
