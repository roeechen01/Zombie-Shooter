using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {

    public Bullet prefabSimpleBullet, prefabHeavyBullet;
    public AudioSource gunFireAudioSource;
    public Collider2D body;

    private Gun gun;
    private Shotgun shotgun;
    private Rifle rifle;
    private Rpg rpg;
    private Sniper sniper;

    public Bomb bomb;

    private double life;
    private double maxLife = 100;
    private bool vulnerable = true;


    private List<Weapon> weapons = new List<Weapon>();
    SpriteRenderer spriteRenderer;

    private Weapon weapon;
    private int weaponIndex = 0;
    public Weapon[] inventory = new Weapon[2];

    public Text ammoText;
    public Text lifeText;

    public AudioClip switchWeaponClip;

    public Gun GetGun() { return this.gun; }
    public Shotgun GetShotgun() { return this.shotgun; }
    public Rifle GetRifle() { return this.rifle; }
    public Rpg GetRpg() { return this.rpg; }
    public Sniper GetSniper() { return this.sniper; }

    // Use this for initialization
    void Start () {
        Zombie.aliveZombies.Clear();
        life = maxLife;
        UpdateText();
        SetComponents();
        weapons.Add(gun);
        weapons.Add(shotgun);
        weapons.Add(rifle);
        weapons.Add(rpg);
        weapons.Add(sniper);

        foreach (Weapon weapon in weapons)
            weapon.SetPlayerAttack(this);
        weapon = weapons[0];
        inventory[0] = weapon;
        spriteRenderer.sprite = weapons[0].sprite;
        InventoryWeapon.ChangeInventory(this.inventory);
        foreach(Weapon weapon in inventory)
            if(weapon)
                weapon.UpdateAmmoText();
    }

    public void AddLife(double life, bool all)
    {
        if (all)
            this.life = this.maxLife;
        else this.life += life;
        if (this.life > this.maxLife)
            this.life = this.maxLife;
        UpdateText();
    }

    void UpdateText()
    {
        double lifeIn100 = life / maxLife * 100;
        if ((int)lifeIn100 <= 0)
            lifeText.text = "DEAD";
        else lifeText.text = "LIFE: " + (int)lifeIn100;
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
        sniper = GetComponent<Sniper>();
    }


    public void Demage(double demage)
    {
        //this.life -= demage;
        //UpdateText();
        MakeUnvulnerable(2f);
        this.life -= demage;
        UpdateText();
        
    }

    public void MakeUnvulnerable(float seconds)
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.4f);
        Invoke("MakeVulnerable", seconds);
        vulnerable = false;
    }


    void MakeVulnerable()
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
        vulnerable = true;
    }

    public bool GetVulnerable()
    {
        return this.vulnerable;
    }

    public Weapon GetWeapon() { return this.weapon; }

    public Weapon GetSecondaryWeapon()
    {
        if (inventory[1] != null)
        {
            if (weapon == inventory[0])
                return inventory[1];
            else return inventory[0];
        }
        else return null;
        
    }

    void SwitchWeapn()
    {
        if (!weapon.IsReloading())
        {
            if(inventory[1] != null)
            {
                AudioSource.PlayClipAtPoint(switchWeaponClip, this.transform.position);
                if (weaponIndex != inventory.Length - 1)
                {
                    weapon = inventory[1];
                    InventoryWeapon.activeIndex = 1;
                    weaponIndex = 1;
                    spriteRenderer.sprite = inventory[weaponIndex].sprite;
                }
                else
                {
                    weapon = inventory[0];
                    InventoryWeapon.activeIndex = 0;
                    weaponIndex = 0;
                    spriteRenderer.sprite = inventory[weaponIndex].sprite;
                }
                weapon.UpdateAmmoText();
                InventoryWeapon.ChangeInventory(this.inventory);

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
                if (weapon.CanFire())
                {
                    weapon.Fire();
                }
                else
                {
                    weapon.WaitBeforeReloadAll();
                }
            }
        }
    }

    public bool Alive()
    {
        try
        {
            return this.life >= 0;
        }
        catch
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update () {
        if (!SetUpGame.onPause)
        {
            FireCheck();
            if (Input.GetKeyDown(KeyCode.R))
                weapon.WaitBeforeReloadAll();
            if (Input.GetKeyDown(KeyCode.E))
                SwitchWeapn();
            if ((int)life / maxLife * 100 <= 0)//The life on the screen is precentage of the life left.
                Dead();
            //if (Input.GetMouseButtonDown((2)))
            //    Instantiate(bomb, this.transform.position, Quaternion.identity);
        }

    }

    void Dead()
    {
        FindObjectOfType<WavesManager>().Dead();
        Zombie[] zombies = FindObjectsOfType<Zombie>();
        foreach (Zombie zombie in zombies)
            Destroy(zombie.gameObject);
        Destroy(FindObjectOfType<ZombieSpawner>().gameObject);
        Destroy(FindObjectOfType<WeaponSpawner>().gameObject);
        Destroy(FindObjectOfType<ItemSpawner>().gameObject);
        Destroy(FindObjectOfType<SniperLaser>().gameObject);
        Destroy(FindObjectOfType<Slider>().gameObject);
        Destroy(gameObject);
    }

}
