using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostZombie : Zombie
{
    private bool visible = true;
    private SpriteRenderer sr;
    private float speedFactor = 1.2f;
    bool toggleStarted = false;

    protected override void CreateZombie()
    {
        CreateZombieTypeInfo(1, 30, 4f);
    }

    void ToggleVisibility()
    {
        if (visible)
        {
            canHit = false;
            visible = false;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.2f);
            this.speed *= this.speedFactor;
        }
        else
        {
            canHit = true;
            visible = true;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
            this.speed /= this.speedFactor;
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

}
