using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWeapon : MonoBehaviour
{
    public int index;
    private Image image;
    public Sprite gun, shotgun, rifle, sniper, rpg;
    private PlayerAttack player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerAttack>();
        image = this.GetComponent<Image>();
        if (image.sprite == null)
            image.color = new Color();
        image.SetNativeSize();
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
            bool active = false;
            if (player.GetWeapon() == inventory[index])
                active = true;
            string name = inventory[index].GetName();
            print(name);
            switch (name)
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
            if(active)
                image.color = new Color(1f, 1f, 1f, 1f);
            else image.color = new Color(1f, 1f, 1f, 0.5f);
            image.preserveAspect = true;

        }

    }
}
