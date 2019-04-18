using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    protected int demage;
    protected float speed;

    protected Vector3 shootDirection;
    protected Rigidbody2D rigidBody2d;

    public bool randomRange = false;
    public Vector2 range = new Vector2(0, 0);

    void Start()
    {
        SetUpGame.MakeSmaller(gameObject);
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    protected void CreateBulletTypeInfo(int demage, float speed, Vector2 range, bool randomRange, int hitsLeft)
    {
        this.demage = demage;
        this.speed = speed;
        this.range = range;
        this.randomRange = randomRange;
        SetVelocity();
    }

    virtual protected void SetVelocity()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        shootDirection = FixVelocity(FindObjectOfType<PlayerController>().transform.position - transform.position);
        ChangeRange();
        rigidBody2d.velocity = FixVelocity(new Vector2(shootDirection.x, shootDirection.y));
        SetBulletSpeed();
        var angle = Mathf.Atan2(rigidBody2d.velocity.y, rigidBody2d.velocity.x) * Mathf.Rad2Deg;
        rigidBody2d.MoveRotation(angle);
    }

    protected void ChangeRange()
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

    protected void SetBulletSpeed()
    {
        float x = rigidBody2d.velocity.x;
        float y = rigidBody2d.velocity.y;
        rigidBody2d.velocity = new Vector2(x * speed, y * speed);
    }

    protected Vector2 FixVelocity(Vector2 velocity)
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
        CreateBulletTypeInfo(5, 10f, range, random, 1);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.GetComponent<PlayerAttack>())
        {
            PlayerAttack player = collider2D.gameObject.GetComponent<PlayerAttack>();
            if (player.GetVulnerable())
            {
                player.Demage(demage);
                Destroy(gameObject);
            }

        }

        else if (collider2D.tag.Equals("Wall"))
            Destroy(gameObject);
    }
}
