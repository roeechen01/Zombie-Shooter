using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {

    public Bullet prefabSimpleBullet, prefabHeavyBullet;
    public AudioSource gunFireAudioSource;


    private Gun gun;
    private Shotgun shotgun;
    private Rifle rifle;
    private Rpg rpg;

    private List<Weapon> weapons = new List<Weapon>();
    SpriteRenderer spriteRenderer;

    private Weapon weapon;
    private int weaponIndex = 0;
    private Weapon[] inventory = new Weapon[2];

    public Gun GetGun() { return this.gun; }
    public Shotgun GetShotgun() { return this.shotgun; }
    public Rifle GetRifle() { return this.rifle; }
    public Rpg GetRpg() { return this.rpg; }

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
        inventory[0] = weapon;
        spriteRenderer.sprite = weapons[0].sprite;
        weapon.WaitBeforeReloadAll();
    }

    void SetComponents()
    {
        gunFireAudioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameObject.AddComponent<PlayerController>();
        gun = GetComponent<Gun>();
        shotgun = GetComponent<Shotgun>();
        rifle = GetComponent<Rifle>();
        rpg = GetComponent<Rpg>();
    }

    public Weapon GetWeapon() { return this.weapon; }

    void SwitchWeapn()
    {
        if (!weapon.IsReloading())
        {
            if(inventory[1] != null)
            {
                if (weaponIndex != inventory.Length - 1)
                {
                    weapon = inventory[++weaponIndex];
                    spriteRenderer.sprite = inventory[weaponIndex].sprite;
                }
                else
                {
                    weapon = inventory[0];
                    spriteRenderer.sprite = inventory[0].sprite;
                    weaponIndex = 0;
                }
                weapon.WaitBeforeReloadAll();

            }
        }
    }

    public void PickupWeapon(Weapon weapon)
    {
        if(inventory[1] != null)
        {
            if (weaponIndex == 0)
                inventory[1] = weapon;
            else inventory[0] = weapon;
        }
        else if(weapon != inventory[0])
        {
            if (weaponIndex == 0)
                inventory[1] = weapon;
            else inventory[0] = weapon;
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
