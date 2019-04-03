using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    protected int demage = 1;
    protected float speed = 12f;

    // Use this for initialization
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag.Equals("Zombie"))
        {
            Destroy(gameObject);
            Zombie zombie = collider2D.gameObject.GetComponent<Zombie>();
            zombie.BulletHit(demage);

        }
    }
}
