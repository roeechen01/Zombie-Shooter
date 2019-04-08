using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRpg : PickupWeapon
{
    protected override void FindWeapon()
    {
        weapon = FindObjectOfType<PlayerAttack>().GetRpg();
    }
}
