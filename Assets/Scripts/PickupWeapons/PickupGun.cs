using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGun : PickupWeapon
{
    protected override void FindWeapon()
    {
        weapon = FindObjectOfType<PlayerAttack>().GetGun();
    }
}