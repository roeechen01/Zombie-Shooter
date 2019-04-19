using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{

    public PickupGun pickupGun;
    public PickupShotgun pickupShotgun;
    public PickupRifle pickupRifle;
    public PickupRpg pickupRpg;
    public PickupSniper pickupSniper;
    public AudioClip pickupSound;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RandomWeapon", 0f, 15f);
        pickupGun.pickupClip = pickupSound;
        pickupShotgun.pickupClip = pickupSound;
        pickupRifle.pickupClip = pickupSound;
        pickupRpg.pickupClip = pickupSound;
        pickupSniper.pickupClip = pickupSound;
    }

    void SpawnWeapon(PickupWeapon pickupWeapon)
    {
        Instantiate(pickupWeapon, new Vector3(Random.Range(-15f, 15f), Random.Range(-15f, 15f), 0f), Quaternion.identity);
    }

    void RandomWeapon()
    {
        int rnd = Random.Range(1, 101);
        if (rnd > 70)
            SpawnWeapon(pickupGun);
        else if (rnd > 50)
            SpawnWeapon(pickupShotgun);
        else if (rnd > 30)
            SpawnWeapon(pickupRifle);
        else if (rnd > 10)
            SpawnWeapon(pickupSniper);
        else
            SpawnWeapon(pickupRpg);
    }
}
