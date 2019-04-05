using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    protected int demage;
    protected float speed;
    protected int ammoRequired;

     void Start() { 
}

    protected void CreateBulletTypeInfo(int demage, float speed, int ammoRequired, Vector2 range)
    {
        this.demage = demage;
        this.speed = speed;
        this.ammoRequired = ammoRequired;
        AddBulletController();
        GetComponent<BulletController>().SetVelocity(range);
    }

    public virtual int GetAmmoRequired()
    {
        return 1;
    }

    virtual protected void OnTriggerEnter2D(Collider2D collider2D)
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
        BulletController bc = gameObject.AddComponent<BulletController>();
        bc.speed = this.speed;
    }
}
