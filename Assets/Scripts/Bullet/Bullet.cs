using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    protected int demage;
    protected float speed;
    protected int ammoRequired;
    Vector3 shootDirection;
    new Rigidbody2D rigidbody2D;

    public bool randomRange = false;
    public Vector2 range = new Vector2(0, 0);

    void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected void CreateBulletTypeInfo(int demage, float speed, int ammoRequired)
    {
        this.demage = demage;
        this.speed = speed;
        this.ammoRequired = ammoRequired;
        SetVelocity();
    }

    protected void CreateBulletTypeInfo(int demage, float speed, int ammoRequired, Vector2 range)
    {
        this.demage = demage;
        this.speed = speed;
        this.ammoRequired = ammoRequired;
        this.range = range;
        SetVelocity();
    }

    protected void CreateBulletTypeInfo(int demage, float speed, int ammoRequired, Vector2 range, bool randomRange)
    {
        this.demage = demage;
        this.speed = speed;
        this.ammoRequired = ammoRequired;
        this.range = range;
        this.randomRange = false;
        SetVelocity();
    }

    void SetVelocity()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        shootDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        ChangeRange();
        rigidbody2D.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
        SetBulletSpeed();
    }

    void ChangeRange()
    {
        if (randomRange)
        {
            shootDirection += new Vector3(Random.Range(-range.x, range.x), Random.Range(-range.y, range.y), 0f);
        }
        else
        {
            shootDirection += new Vector3(range.x, range.y, 0f);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void SetBulletSpeed()
    {
        float x = rigidbody2D.velocity.x;
        float y = rigidbody2D.velocity.y;
        if (x != 0 || y != 0)
        {
            if (x > 1 || x < -1 || y > 1 || y < -1)
            {
                while (x > 1 || x < -1 || y > 1 || y < -1)
                {
                    x /= 1.001f;
                    y /= 1.001f;
                }
                rigidbody2D.velocity = new Vector2(x * speed, y * speed);
            }
            else
            {
                if (x < 1 && x > -1 || y < 1 && y > -1)
                {
                    while ((x < 1 && x > -1) && (y < 1 && y > -1))
                    {
                        x *= 1.001f;
                        y *= 1.001f;
                    }
                    rigidbody2D.velocity = new Vector2(x * speed, y * speed);
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }

   

    

    public virtual int GetAmmoRequired()
    {
        return 1;
    }

    public virtual void CreateBullet(Vector2 range, bool random)
    {

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
}
