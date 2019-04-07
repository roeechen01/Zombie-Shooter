﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    private PlayerAttack player;
    new Rigidbody2D rigidbody2D;
    public Collider2D head;
    private Vector3 direction;

    protected int life;
    protected int demage;
    protected float speed;



    // Use this for initialization
    protected void Start () {
        CreateZombie();
        player = FindObjectOfType<PlayerAttack>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected void CreateZombieTypeInfo(int life, int demage, float speed)
    {
        this.life = life;
        this.demage = demage;
        this.speed = speed;
        
    }

    virtual protected void CreateZombie()
    {

    }

    void Rotaion()
    {
        Vector3 player_pos = Camera.main.WorldToScreenPoint(player.transform.position);
        Vector3 object_pos = Camera.main.WorldToScreenPoint(transform.position);
        player_pos -= object_pos;
        float angle = Mathf.Atan2(player_pos.y, player_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void SetZombieSpeed()
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

    }

    void SetVelocity()
    {
        direction = Camera.main.ScreenToWorldPoint(player.transform.position) - Camera.main.ScreenToWorldPoint(transform.position);
        rigidbody2D.velocity = new Vector2(direction.x * speed, direction.y * speed);
        SetZombieSpeed();
    }

    public void BulletHit(int demage)
    {
        life -= demage;
        if (life <= 0)
            Destroy(gameObject);
    }

    public virtual void HeadShot(int demage)
    {
        BulletHit(demage * 2);
        print("headshot: " + gameObject.name);
    }

    // Update is called once per frame
    void Update () {
        Rotaion();
        SetVelocity();
        
    }
}
