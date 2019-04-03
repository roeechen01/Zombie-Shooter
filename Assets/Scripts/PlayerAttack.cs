using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {

    public Bullet prefabBullet;
    private int ammo = 10;
    private int ammoMax;
    private Text ammoText;

    public AudioClip reload;
    public AudioClip gunfire;


    // Use this for initialization
    void Start () {
        ammoText = FindObjectOfType<Text>();
        ammoMax = ammo;
        ammoText.text = "AMMO: " + ammo;
        //ReloadRepeat();
    }

    void ReloadRepeat()
    {
        InvokeRepeating("Reload", 0f, 1f);
    }

    void AmmoChange(int ammoChange)
    {
        ammo += ammoChange;
        ammoText.text = "AMMO: " + ammo;
    }

    void Reload()
    {
        if(ammo<ammoMax)
            AmmoChange(1);
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ammo > 0)
            {
                AudioSource.PlayClipAtPoint(gunfire, this.transform.position);
                Instantiate(prefabBullet, this.transform.position, transform.rotation);
                AmmoChange(-1);
            }

            else
            {
                Wait("ReloadAll", 1);
                AudioSource.PlayClipAtPoint(reload, this.transform.position);
            }
        }
    }


    // Update is called once per frame
    void Update () {
        Fire();
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (ammo != ammoMax)
            {
                AudioSource.PlayClipAtPoint(reload, this.transform.position);
                Wait("ReloadAll", 1);
            }
        }
    }

    void ReloadAll()
    {
        if(ammo != ammoMax)
        {
            ammo = ammoMax;
            ammoText.text = "AMMO: " + ammo;
        }
        
    }

    void Wait(string methodName ,float seconds)
    {
        Invoke(methodName, seconds);
    }
}
