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

    private double life;
    private double maxLife = 100;
    private bool vulnerable = true;


    private List<Weapon> weapons = new List<Weapon>();
    SpriteRenderer spriteRenderer;

    private Weapon weapon;
    private int weaponIndex = 0;
    private Weapon[] inventory = new Weapon[2];

    public Text ammoText;
    public Text lifeText;

    public AudioClip switchWeaponClip;

    public Gun GetGun() { return this.gun; }
    public Shotgun GetShotgun() { return this.shotgun; }
    public Rifle GetRifle() { return this.rifle; }
    public Rpg GetRpg() { return this.rpg; }

    // Use this for initialization
    void Start () {
        life = maxLife;
        UpdateText();
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
    }


    public void Demage(double demage)
    {
        //this.life -= demage;
        //UpdateText();
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.4f);
        this.life -= demage;
        UpdateText();
        Invoke("MakeVulnerable", 2f);
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

    void SwitchWeapn()
    {
        if (!weapon.IsReloading())
        {
            if(inventory[1] != null)
            {
                AudioSource.PlayClipAtPoint(switchWeaponClip, this.transform.position);
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
                weapon.UpdateAmmoText();
                //weapon.WaitBeforeReloadAll();

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
        FireCheck();
        if (Input.GetKeyDown(KeyCode.R))
            weapon.WaitBeforeReloadAll();
        if(Input.GetKeyDown(KeyCode.E))
            SwitchWeapn();
        if ((int)life / maxLife * 100 <= 0)//The life on the screen is precentage of the life left.
            Death();
    }

    void Death()
    {
        Zombie[] zombies = FindObjectsOfType<Zombie>();
        foreach (Zombie zombie in zombies)
            Destroy(zombie.gameObject);
        Bullet[] bullets = FindObjectsOfType<Bullet>();
        foreach (Bullet bullet in bullets)
            Destroy(bullet.gameObject);
        Destroy(FindObjectOfType<ZombieSpawner>());
        Destroy(FindObjectOfType<WeaponSpawner>());
        Destroy(gameObject);
    }

}
