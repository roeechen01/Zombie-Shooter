using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    protected int demageMax;
    protected float speed;
    protected int hitsMax = 1;
    protected int hitsLeft;

    Vector3 shootDirection;
    Rigidbody2D rigidBody2d;
    public Weapon weapon;

    public bool randomRange = false;
    public Vector2 range = new Vector2(0, 0);

    void Start() {
        SetUpGame.MakeSmaller(gameObject);
        rigidBody2d = GetComponent<Rigidbody2D>();
        hitsLeft = hitsMax;
    }

    protected void CreateBulletTypeInfo(Weapon weapon, int demage, float speed, Vector2 range, bool randomRange, int hitsLeft)
    {
        this.demageMax = demage;
        this.speed = speed;
        this.range = range;
        this.weapon = weapon;
        this.randomRange = randomRange;
        this.hitsMax = hitsLeft;
        SetVelocity();
    }

    protected void CreateBulletTypeInfo(Weapon weapon, int demage, float speed, Vector2 range, bool randomRange)
    {
        this.demageMax = demage;
        this.speed = speed;
        this.range = range;
        this.weapon = weapon;
        this.randomRange = randomRange;
        this.hitsMax = 1;
        SetVelocity();
    }

    void SetVelocity()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        shootDirection = FixVelocity(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        ChangeRange();
        rigidBody2d.velocity = FixVelocity(new Vector2(shootDirection.x, shootDirection.y));
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

    void SetBulletSpeed()
    {
        float x = rigidBody2d.velocity.x;
        float y = rigidBody2d.velocity.y;
        rigidBody2d.velocity = new Vector2(x * speed, y * speed);
    }

    Vector2 FixVelocity(Vector2 velocity)
    {
        float x = velocity.x;
        float y = velocity.y;
        if (x != 0 || y != 0)
        {
            if (x > 1 || x < -1 || y > 1 || y < -1)
            {
                while (x > 1 || x < -1 || y > 1 || y < -1)
                {
                    x /= 1.001f;
                    y /= 1.001f;
                }
                velocity = new Vector2(x, y);
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
                    velocity = new Vector2(x, y);
                }
            }
            return velocity;
        }
        else
        {
            Destroy(gameObject);
            return new Vector2(0f, 0f);

        }
    }

    public virtual void CreateBullet(Weapon weapon ,Vector2 range, bool random)
    {

    }

    protected virtual void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.GetComponent<Zombie>())
        {
            Zombie zombie = collider2D.gameObject.GetComponent<Zombie>();
            if (zombie.CanHit())
            {
                if (collider2D.Equals(zombie.head))
                    zombie.HeadShot((int)GetDemageBasedOnHits());
                else zombie.Hit((int)GetDemageBasedOnHits());
                this.hitsLeft--;
                if (hitsLeft == 0)
                    Destroy(gameObject);
            }
            
        }

        else if (collider2D.tag.Equals("Wall"))
            Destroy(gameObject);
    }

    double GetDemageBasedOnHits()
    {
        return demageMax * (double)hitsLeft / hitsMax;
    }
}
