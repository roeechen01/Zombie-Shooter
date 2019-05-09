using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public HealthPack healthPack;
    public SmallHealthPack smallHealthPack;
    public InvisibilityPotion invisibilityPotion;
    public AmmoPack ammoPack;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RandomItem", 15f, 15f);
    }

    void SpawnItem(Item item)
    {
        Instantiate(item, new Vector3(Random.Range(-15f, 15f), Random.Range(-15f, 15f), 1f), Quaternion.identity);
    }

    void RandomItem()
    {
        int rnd = Random.Range(1, 101);
        if (rnd > 80)
            SpawnItem(invisibilityPotion);
        else if (rnd > 60)
            SpawnItem(ammoPack);
        else if (rnd > 20)
            SpawnItem(smallHealthPack);
        else
            SpawnItem(healthPack);
    }

}
