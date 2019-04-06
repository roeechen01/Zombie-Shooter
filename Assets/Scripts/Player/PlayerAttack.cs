using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {

    public Bullet prefabSimpleBullet, prefabHeavyBullet;

    private Gun gun;
    private Shotgun shotgun;

    private List<Weapon> weapons = new List<Weapon>();
    public List<Sprite> weaponsSprites = new List<Sprite>();
    SpriteRenderer spriteRenderer;

    private Weapon weapon;
    private int weapnIndex = 0;

    private int ammo = 25;
    private int ammoMax;
    private Text ammoText;
    private bool reloading = false;

    private AudioSource reloadAudioSource;


    // Use this for initialization
    void Start () {
        SetComponents();
        ammoMax = ammo;
        ammoText.text = "AMMO: " + ammo;

        weapons.Add(gun);
        weapons.Add(shotgun);
        foreach (Weapon weapon in weapons)
            weapon.SetPlayerAttack(this);
        weapon = weapons[0];
        spriteRenderer.sprite = weaponsSprites[0];
    }

    void SetComponents()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameObject.AddComponent<PlayerController>();
        reloadAudioSource = GetComponent<AudioSource>();
        ammoText = FindObjectOfType<Text>();
        gun = GetComponent<Gun>();
        shotgun = GetComponent<Shotgun>();
    }

    void SwitchWeapn()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(weapnIndex == 0)
            {
                weapon = weapons[++weapnIndex];
                spriteRenderer.sprite = weaponsSprites[weapnIndex];
            }
            else 
            {
                weapon = weapons[--weapnIndex];
                spriteRenderer.sprite = weaponsSprites[weapnIndex];
            }
        }
    }

    void PlayReloadClip()
    {
        if (!reloadAudioSource.isPlaying)
            reloadAudioSource.Play();
    }

    void ReloadRepeat()
    {
        InvokeRepeating("Reload", 0f, 1f);
    }

    public void AmmoChange(int ammoChange)
    {
        ammo += ammoChange;
        ammoText.text = "AMMO: " + ammo;
    }

    void Reload()
    {
        if(ammo < ammoMax)
            AmmoChange(1);
    }

    void FireCheck()
    {
        if (!reloading)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (weapon.CanFire(ammo)) weapon.Fire();
                else WaitBeforeReloadAll();
            }
        }
    }

    // Update is called once per frame
    void Update () {
        FireCheck();
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (ammo != ammoMax)
                WaitBeforeReloadAll();
        }
        SwitchWeapn();
    }

    void ReloadAll()
    {
        if(ammo != ammoMax)
        {
            ammo = ammoMax;
            reloading = false;
            ammoText.text = "AMMO: " + ammo;
        }
        
    }

    void Wait(string methodName ,float seconds)
    {
        Invoke(methodName, seconds);
    }

    void WaitBeforeReloadAll()
    {
        reloading = true;
        ammoText.text = "Reloading...";
        PlayReloadClip();
        Wait("ReloadAll", 1);
    }
}
