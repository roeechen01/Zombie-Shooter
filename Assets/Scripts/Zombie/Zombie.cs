﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public static List<Zombie> aliveZombies = new List<Zombie>();

    private PlayerAttack player;
    Rigidbody2D rigidBody2d;
    private Vector3 direction;
    public Collider2D head;

    protected int life;
    protected double demage;
    protected float speed;
    protected bool canHit = true;
    protected bool boss = false;


    // Use this for initialization
    protected void Start () {
        aliveZombies.Add(this);
        General.MakeSmaller(gameObject);
        CreateZombie();
        player = FindObjectOfType<PlayerAttack>();
        rigidBody2d = GetComponent<Rigidbody2D>();
        InvokeRepeating("CheckForSamePosZombies", 4.765f, 5f);
    }

    protected void CreateZombieTypeInfo(int life, double demage, float speed)
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
        float x = rigidBody2d.velocity.x;
        float y = rigidBody2d.velocity.y;
        if (x != 0 || y != 0)
        {
            if (x > 1 || x < -1 || y > 1 || y < -1)
            {
                while (x > 1 || x < -1 || y > 1 || y < -1)
                {
                    x /= 1.001f;
                    y /= 1.001f;
                }
                rigidBody2d.velocity = new Vector2(x * speed, y * speed);
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
                    rigidBody2d.velocity = new Vector2(x * speed, y * speed);
                }
            }
        }

    }

    void SetVelocity()
    {
        direction = Camera.main.ScreenToWorldPoint(player.transform.position) - Camera.main.ScreenToWorldPoint(transform.position);
        rigidBody2d.velocity = new Vector2(direction.x * speed, direction.y * speed);
        SetZombieSpeed();
    }

    public bool CanHit()
    {
        return this.canHit;
    }

    public virtual void Hit(int demage)
    {
        life -= demage;
        if (life <= 0)
            Dead();
    }

    public void Dead()
    {
        aliveZombies.Remove(this);
        Destroy(gameObject);
    }

    public virtual void HeadShot(int demage)
    {
        Hit(demage * 3);
    }

    public bool IsBoss()
    {
        return this.boss;
    }

    // Update is called once per frame
    void Update () {
            Rotaion();
            SetVelocity();
    }

    void CheckForSamePosZombies()
    {
        foreach (Zombie zombie in aliveZombies)
            if (ClosePosition(this.transform.position, zombie.transform.position, 0.01f) && zombie != this && this.name.Equals(zombie.name))
            {
                print("found zombies in same position");
                Dead();
                break;
            }
    }

    bool CloseFloats(float num1, float num2, float closeDiff)
    {
        return (num1 + closeDiff >= num2 && num1 - closeDiff <= num2) || (num2 + closeDiff >= num1 && num2 - closeDiff <= num1);
    }

    bool ClosePosition(Vector3 pos1, Vector3 pos2, float closeDiff)
    {
        return CloseFloats(pos1.x, pos2.x, closeDiff) && CloseFloats(pos1.y, pos2.y, closeDiff);
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag.Equals("Player"))
        {
            SpriteRenderer sr = FindObjectOfType<PlayerAttack>().GetComponent<SpriteRenderer>();
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.2f);
            //CancelInvoke("DemagingPlayer");
            //InvokeRepeating("DemagingPlayer", 0.2f, 0.8f);
            DemagingPlayer();
            rigidBody2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag.Equals("Player"))
        {
            rigidBody2d.constraints = RigidbodyConstraints2D.FreezeAll;
            DemagingPlayer();
        }

    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        //CancelInvoke("DemagingPlayer");
        rigidBody2d.constraints = RigidbodyConstraints2D.None;
    }

    void DemagingPlayer()
    {
        if (player.GetVulnerable())
        {
            PlayerAttack player = FindObjectOfType<PlayerAttack>();
            player.Demage(demage);
        }
        
    }
}
