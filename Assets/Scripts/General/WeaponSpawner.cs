using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{

    public PickupGun pickupGun;
    public PickupShotgun pickupShotgun;
    public PickupRifle pickupRifle;
    public PickupRpg pickupRpg;
    public AudioClip pickupSound;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RandomWeapon", 15f, 15f);
        pickupGun.pickupClip = pickupSound;
        pickupShotgun.pickupClip = pickupSound;
        pickupRifle.pickupClip = pickupSound;
        pickupRpg.pickupClip = pickupSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnWeapon(PickupWeapon pickupWeapon)
    {
        Instantiate(pickupWeapon, new Vector3(Random.Range(-15f, 15f), Random.Range(-15f, 15f), 0f), Quaternion.identity);
    }

    void RandomWeapon()
    {
        int rnd = Random.Range(1, 101);
        if (rnd > 60)
            SpawnWeapon(pickupGun);
        else if (rnd > 30)
            SpawnWeapon(pickupShotgun);
        else if (rnd > 10)
            SpawnWeapon(pickupRifle);
        else 
            SpawnWeapon(pickupRpg);
    }
}
