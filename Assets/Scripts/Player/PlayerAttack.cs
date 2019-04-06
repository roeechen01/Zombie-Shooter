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




    // Use this for initialization
    void Start () {
        SetComponents();
        weapons.Add(gun);
        weapons.Add(shotgun);
        foreach (Weapon weapon in weapons)
            weapon.SetPlayerAttack(this);
        weapon = weapons[0];
        spriteRenderer.sprite = weaponsSprites[0];
        weapon.WaitBeforeReloadAll();
    }

    void SetComponents()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameObject.AddComponent<PlayerController>();
        gun = GetComponent<Gun>();
        shotgun = GetComponent<Shotgun>();
    }

    void SwitchWeapn()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!weapon.reloading)
            {
                if (weapnIndex == 0)
                {
                    weapon = weapons[++weapnIndex];
                    spriteRenderer.sprite = weaponsSprites[weapnIndex];
                }
                else
                {
                    weapon = weapons[--weapnIndex];
                    spriteRenderer.sprite = weaponsSprites[weapnIndex];
                }
                weapon.WaitBeforeReloadAll();
            }
            

        }
    }

    

    void FireCheck()
    {
        if (!weapon.reloading)
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
        {
            weapon.WaitBeforeReloadAll();
        }
        SwitchWeapn();
    }

}
