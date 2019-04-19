using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSniper : PickupWeapon
{
    protected override void FindWeapon()
    {
        weapon = FindObjectOfType<PlayerAttack>().GetSniper();
    }
}
