using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPack : Item
{
    protected override void Ability()
    {
        foreach (Weapon weapon in player.inventory)
        {
            if (weapon)
            {
                weapon.AddToAmmo(weapon.GetStackMax() * 2);
                if (weapon.GetAmmoLeft() > weapon.GetAmmoMax() - weapon.GetStackMax())
                    weapon.SetAmmoToMax();
                weapon.UpdateAmmoText();
            }
        }
    }
}
