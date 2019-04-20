using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWeapon : MonoBehaviour
{
    public int index;
    private Image image;
    public Sprite gun, shotgun, rifle, sniper, rpg;
    private static PlayerAttack player;
    private InventoryAmmo ammoText;
    public static int activeIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerAttack>();
        image = this.GetComponent<Image>();
        if (image.sprite == null)
            image.color = new Color();
        foreach(InventoryAmmo ammo in FindObjectsOfType<InventoryAmmo>())
        {
            if(this.index == ammo.index)
            {
                this.ammoText = ammo;
                break;
            }
        }
    }

    public static void ChangeInventory(Weapon[] inventory)
    {
        InventoryWeapon[] inventoryWeapons = FindObjectsOfType<InventoryWeapon>();
        foreach (InventoryWeapon inventoryWeapon in inventoryWeapons)
            inventoryWeapon.Change(inventory);
    }

    void Change(Weapon[] inventory)
    {
        if (inventory[index] == null)
            image.color = new Color();
        else
        {
            image.sprite = null;
            switch (inventory[index].GetName())
            {
                case "Gun":
                    image.sprite = gun;
                    break;
                case "Shotgun":
                    image.sprite = shotgun;
                    break;
                case "Rifle":
                    image.sprite = rifle;
                    break;
                case "Sniper":
                    image.sprite = sniper;
                    break;
                case "Rpg":
                    image.sprite = rpg;
                    break;
                default:
                    image.color = new Color();
                    break;
            }

            if(player.GetWeapon() == inventory[index])
                image.color = new Color(1f, 1f, 1f, 1f);
            else image.color = new Color(1f, 1f, 1f, 0.5f);
            ChangeTextVisibility(inventory[index].GetName());
           
        }
        image.preserveAspect = true;

    }

    public Text GetAmmoText(Weapon weapon)
    {
        if(weapon == player.GetWeapon())
        {
            if (this.index == activeIndex)
            {
                return this.ammoText.text;
            }
        }
        else
        {
            if (this.index != activeIndex)
            {
                return this.ammoText.text;
            }
        }
        return null;
    }

    public void ChangeTextVisibility(string name)
    {
        print(name + ": " + this.image.color.a);
        this.ammoText.text.color = this.image.color;
    }

    public static Text GetText(Weapon weapon)
    {
        InventoryWeapon[] inventoryWeapons = FindObjectsOfType<InventoryWeapon>();
        foreach (InventoryWeapon inventoryWeapon in inventoryWeapons)
            if(inventoryWeapon.GetAmmoText(weapon) != null)
                return inventoryWeapon.GetAmmoText(weapon);
        return null;
    }
}
