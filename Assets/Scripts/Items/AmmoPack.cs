using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPack : Item
{
    protected override void Ability()
    {
        Weapon weapon = player.GetWeapon();
        weapon.AddToAmmo(weapon.GetStackMax() * 3);
        if (weapon.GetAmmoLeft() > weapon.GetAmmoMax()  - weapon.GetStackMax())
            weapon.SetAmmoToMax();
        weapon.UpdateAmmoText();

    }
}
