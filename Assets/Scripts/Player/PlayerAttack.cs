using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {

    public Bullet prefabSimpleBullet, prefabHeavyBullet;

    private Gun gun;
    private Shotgun shotgun;
    private Rifle rifle;
    private Rpg rpg;

    private List<Weapon> weapons = new List<Weapon>();
    SpriteRenderer spriteRenderer;

    private Weapon weapon;
    private int weaponIndex = 0;

    // Use this for initialization
    void Start () {
        SetComponents();
        weapons.Add(gun);
        weapons.Add(shotgun);
        weapons.Add(rifle);
        weapons.Add(rpg);

        foreach (Weapon weapon in weapons)
            weapon.SetPlayerAttack(this);
        weapon = weapons[0];
        spriteRenderer.sprite = weapons[0].sprite;
        weapon.WaitBeforeReloadAll();
    }

    void SetComponents()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameObject.AddComponent<PlayerController>();
        gun = GetComponent<Gun>();
        shotgun = GetComponent<Shotgun>();
        rifle = GetComponent<Rifle>();
        rpg = GetComponent<Rpg>();
    }

    void SwitchWeapn()
    {
            if (!weapon.IsReloading())
            {
                //if (weapnIndex == 0)
                //{
                //    weapon = weapons[++weapnIndex];
                //    spriteRenderer.sprite = weapons[weapnIndex].sprite;
                //}
                //else
                //{
                //    weapon = weapons[--weapnIndex];
                //    spriteRenderer.sprite = weapons[weapnIndex].sprite;
                //}
                if (weaponIndex != weapons.Count-1)
                {
                    weapon = weapons[++weaponIndex];
                    spriteRenderer.sprite = weapons[weaponIndex].sprite;
                }
                else
                {
                    weapon = weapons[0];
                    spriteRenderer.sprite = weapons[0].sprite;
                    weaponIndex = 0;
                }

                weapon.WaitBeforeReloadAll();
            }
    }

    

    void FireCheck()
    {
        if (!weapon.IsReloading())
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (weapon.CanFire()) weapon.Fire();
                else weapon.WaitBeforeReloadAll();
            }
        }
    }

    // Update is called once per frame
    void Update () {
        FireCheck();
        if (Input.GetKeyDown(KeyCode.R))
            weapon.WaitBeforeReloadAll();
        if(Input.GetKeyDown(KeyCode.E))
            SwitchWeapn();
    }

}
