using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    private Zombie zombie;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestroy", 0.2f);
    }

    public void SelfDestroy()
    {
        GetComponent<SpriteRenderer>().sprite = null;
    }

    public bool Exist()
    {
        return GetComponent<SpriteRenderer>().sprite != null;
    }

    public void SetZombie(Zombie zombie)
    {
        this.zombie = zombie;
    }

    void Update()
    {
        if (!zombie)
            SelfDestroy();



    }
}
