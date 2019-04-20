using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPack : Item
{
    protected override void Ability()
    {
        Weapon weapon = player.GetWeapon();
        weapon.AddToAmmo(weapon.GetStackMax() * 2);
        if (weapon.GetAmmoLeft() > weapon.GetAmmoMax()  - weapon.GetStackMax())
            weapon.SetAmmoToMax();
        weapon.UpdateAmmoText();
        Weapon secondary = player.GetSecondaryWeapon();
        if (secondary != null)
        {
            secondary.AddToAmmo(secondary.GetStackMax() * 2);
            if (secondary.GetAmmoLeft() > secondary.GetAmmoMax() - secondary.GetStackMax())
                secondary.SetAmmoToMax();
            secondary.UpdateAmmoText();
        }
    }
}
