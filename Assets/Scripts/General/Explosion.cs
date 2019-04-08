using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestoryItself", 0.5f);
    }

    void DestoryItself()
    {
        Destroy(gameObject);
    }

    virtual protected void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag.Equals("Zombie"))
        {
            Zombie zombie = collider2D.gameObject.GetComponent<Zombie>();
            Destroy(zombie.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
