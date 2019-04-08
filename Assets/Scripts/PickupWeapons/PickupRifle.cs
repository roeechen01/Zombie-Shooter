using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRifle : PickupWeapon
{
    protected override void FindWeapon()
    {
        weapon = FindObjectOfType<PlayerAttack>().GetRifle();
    }
}