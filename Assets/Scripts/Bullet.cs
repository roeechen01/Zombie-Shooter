using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    protected int demage;
    protected float speed;

    protected void CreateBulletTypeInfo(int demage, float speed)
    {
        this.demage = demage;
        this.speed = speed;
        AddBulletController();
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

    private void AddBulletController()
    {
        gameObject.AddComponent<BulletController>();
        GetComponent<BulletController>().speed = this.speed;
    }
}
