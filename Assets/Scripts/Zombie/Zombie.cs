using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public static List<Zombie> aliveZombies = new List<Zombie>();
    private ZombieSpawner zombieSpawner;
    private WavesManager wavesManager;

    public Blood blood;
    public List<Blood> bloods = new List<Blood>();

    protected PlayerAttack player;
    protected Rigidbody2D rigidBody2d;
    private Vector3 direction;
    public Collider2D head;

    protected int life;
    protected double demage;
    protected float speed;
    protected bool canHit = true;

    public Vector2 velocity;


    // Use this for initialization
    protected void Start () {
        zombieSpawner = FindObjectOfType<ZombieSpawner>();
        wavesManager = FindObjectOfType <WavesManager>();
        aliveZombies.Add(this);
        SetUpGame.MakeSmaller(gameObject);
        CreateZombie();
        TargetNewPlayer();
        rigidBody2d = GetComponent<Rigidbody2D>();
        InvokeRepeating("CheckForSamePosZombies", 4.765f, 5f);
    }

    void TargetNewPlayer()
    {
        player = FindObjectsOfType<PlayerAttack>()[Random.Range(0, FindObjectsOfType<PlayerAttack>().Length)];
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

    protected virtual void Rotaion()
    {
        Vector3 player_pos = Camera.main.WorldToScreenPoint(player.transform.position);
        Vector3 object_pos = Camera.main.WorldToScreenPoint(transform.position);
        player_pos -= object_pos;
        float angle = Mathf.Atan2(player_pos.y, player_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    protected void SetZombieSpeed()
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

        if (rigidBody2d.velocity.x == 0 || rigidBody2d.velocity.y == 0 && this is RunnerZombie)
        {
            Destroy(gameObject);
        }
            

    }

    protected virtual void SetVelocity()
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

    public virtual void Dead()
    {
        
        this.CancelInvoke();
        aliveZombies.Remove(this);
        foreach(Blood blood in bloods)
            if (blood.Exist())
                blood.SelfDestroy();
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        if (zombieSpawner.FinishedWaveCheck() && wavesManager.noMore)
            wavesManager.Win();
    }

    public virtual void HeadShot(int demage)
    {
        Hit(demage * 3);
    }

    // Update is called once per frame
    protected void Update () {
        Rotaion();
        SetVelocity();
        velocity = rigidBody2d.velocity;
        foreach (Blood blood in bloods)
            if (blood.Exist())
            {
                blood.GetComponent<Rigidbody2D>().velocity = this.rigidBody2d.velocity;
                blood.GetComponent<Rigidbody2D>().constraints = this.rigidBody2d.constraints;
            }
    }

    void CheckForSamePosZombies()
    {
        foreach (Zombie zombie in aliveZombies)
            if (zombie && ClosePosition(this.transform.position, zombie.transform.position, 0.05f) && zombie != this && this.name.Equals(zombie.name))
            {
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

    protected virtual void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag.Equals("Player") && player.body == collider2D)
        {
            DemagingPlayer();
            rigidBody2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        Bullet bullet = collider2D.gameObject.GetComponent<Bullet>();
        if (bullet && canHit)
        {
            Blood tempBlood = Instantiate(blood, new Vector3(bullet.transform.position.x, bullet.transform.position.y, -1f), Quaternion.identity);
            bloods.Add(tempBlood);
            tempBlood.SetZombie(this);
        }

    }

    protected virtual void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag.Equals("Player") && player.body == collider2D)
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

    protected virtual void DemagingPlayer()
    {
        if (player.GetVulnerable())
        {
            SpriteRenderer sr = FindObjectOfType<PlayerAttack>().GetComponent<SpriteRenderer>();
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.2f);
            PlayerAttack player = FindObjectOfType<PlayerAttack>();
            player.Demage(demage);
        }
        
    }
}
