using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibilityPotion : Item
{
    protected override void Ability()
    {
        player.MakeUnvulnerable(5);
    }
}
