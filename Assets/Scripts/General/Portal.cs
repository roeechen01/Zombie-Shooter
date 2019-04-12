using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    void Start()
    {
        General.MakeSmaller(gameObject);
    }
    public void Spawn(Zombie zombie)
    {
        Instantiate(zombie, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }
}
