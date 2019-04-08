using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{

    public PickupGun pickupGun;
    public PickupShotgun pickupShotgun;
    public PickupRifle pickupRifle;
    public PickupRpg pickupRpg;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RandomWeapon", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnWeapon(PickupWeapon pickupWeapon)
    {
        Instantiate(pickupWeapon, new Vector3(Random.Range(-15f, 15f), Random.Range(-15f, 18f), 0f), Quaternion.identity);
    }

    void RandomWeapon()
    {
        int rnd = Random.Range(1, 101);
        if (rnd < 40)
            SpawnWeapon(pickupGun);
        if (rnd < 30)
            SpawnWeapon(pickupShotgun);
        if (rnd < 20)
            SpawnWeapon(pickupRifle);
        if (rnd < 10)
            SpawnWeapon(pickupRpg);
    }
}
