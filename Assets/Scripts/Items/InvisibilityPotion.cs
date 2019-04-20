using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibilityPotion : Item
{
    protected override void Ability()
    {
        player.CancelInvoke("MakeVulnerable");
        player.MakeUnvulnerable(5);
    }
}
