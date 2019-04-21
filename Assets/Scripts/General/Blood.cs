using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public Zombie zombie;
    bool invoked = false;
    public static bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        
        if (!active)
            SelfDestroy();
        else Invoke("SelfDestroy", 0.2f);

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
        if (!zombie && !invoked)
        {
            invoked = true;
            Invoke("RealDestroy", 0.2f);
        }
    }

    void RealDestroy()
    {
        Destroy(gameObject);
    }
}
