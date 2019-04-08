using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupShotgun : PickupWeapon
{
    protected override void FindWeapon()
    {
        weapon = FindObjectOfType<PlayerAttack>().GetShotgun();
    }
}