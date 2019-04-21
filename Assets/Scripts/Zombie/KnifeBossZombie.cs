using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeBossZombie : Boss
{
    private bool visible = true;
    private SpriteRenderer sr;
    private float speedFactor = 1.4f;
    private bool toggleStarted = false;

    protected override void CreateZombie()
    {
        CreateZombieTypeInfo(120, 30, 4f);
    }

    void ToggleVisibility()
    {
        if (visible)
        {
            MakeInvisible();
        }
        else
        {
            MakeVisible();
        }
    }

    void OnBecameVisible()
    {
        if (!toggleStarted)
        {
            toggleStarted = true;
            sr = GetComponent<SpriteRenderer>();
            InvokeRepeating("ToggleVisibility", 1f, 2f);
        }
    }

    void MakeVisible()
    {
        canHit = true;
        visible = true;
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        this.speed  = 4f;
    }

    void MakeInvisible()
    {
        canHit = false;
        visible = false;
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.2f);
        this.speed *= this.speedFactor;
    }

    protected override void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag.Equals("Player") && player.body == collider2D)
        {
            if (player.GetVulnerable())
            {
                DemagingPlayer();
                this.transform.localScale = new Vector3(transform.localScale.x * 1.2f, transform.localScale.y * 1.2f);
                demage += 10f;
                speedFactor += 0.2f;
                rigidBody2d.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }

        Bullet bullet = collider2D.gameObject.GetComponent<Bullet>();
        if (bullet && canHit)
        {
            Blood tempBlood = Instantiate(blood, new Vector3(bullet.transform.position.x, bullet.transform.position.y, -1f), Quaternion.identity);
            bloods.Add(tempBlood);
            tempBlood.SetZombie(this);
        }

    }
}
