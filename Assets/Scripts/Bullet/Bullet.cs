using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    protected int demage;
    protected float speed;
    Vector3 shootDirection;
    new Rigidbody2D rigidbody2D;

    public bool randomRange = false;
    public Vector2 range = new Vector2(0, 0);

    void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected void CreateBulletTypeInfo(int demage, float speed)
    {
        this.demage = demage;
        this.speed = speed;
        SetVelocity();
    }

    protected void CreateBulletTypeInfo(int demage, float speed, Vector2 range)
    {
        this.demage = demage;
        this.speed = speed;
        this.range = range;
        SetVelocity();
    }

    protected void CreateBulletTypeInfo(int demage, float speed, Vector2 range, bool randomRange)
    {
        this.demage = demage;
        this.speed = speed;
        this.range = range;
        this.randomRange = randomRange;
        SetVelocity();
    }

    void SetVelocity()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        shootDirection = FixVelocity(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        ChangeRange();
        rigidbody2D.velocity = FixVelocity(new Vector2(shootDirection.x, shootDirection.y));
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
        Invoke("DestroyBullet", 5f);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    void SetBulletSpeed()
    {
        float x = rigidbody2D.velocity.x;
        float y = rigidbody2D.velocity.y;
        rigidbody2D.velocity = new Vector2(x * speed, y * speed);
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

    public virtual void CreateBullet(Vector2 range, bool random)
    {

    }

    virtual protected void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag.Equals("Zombie"))
        {
            Destroy(gameObject);
            Zombie zombie = collider2D.gameObject.GetComponent<Zombie>();
            if (collider2D.Equals(zombie.head))
                zombie.HeadShot(demage);
            else zombie.BulletHit(demage);
        }
    }
}
