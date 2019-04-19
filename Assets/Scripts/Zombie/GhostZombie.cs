using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostZombie : Zombie
{
    private bool visible = true;
    private SpriteRenderer sr;
    private float speedFactor = 1.2f;
    private bool toggleStarted = false;
    //private int modeCounter = 0;
    

    protected override void CreateZombie()
    {
        CreateZombieTypeInfo(2, 25, 4f);
    }

    //void ChangeModeCounter()
    //{
    //    if (modeCounter == 3)
    //        modeCounter = 0;
    //    modeCounter++;
    //    if(modeCounter == 1)
    //    {
    //        ToggleVisibility();
    //    }
    //    if(modeCounter == 2)
    //    {
    //        ToggleVisibility();
    //    }
    //}

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
            //InvokeRepeating("ChangeModeCounter", 1f, 2f);
            InvokeRepeating("ToggleVisibility", 2f, 2f);
        }
    }

    void MakeVisible()
    {
        canHit = true;
        visible = true;
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        this.speed /= this.speedFactor;
    }

    void MakeInvisible()
    {
        canHit = false;
        visible = false;
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.2f);
        this.speed *= this.speedFactor;
    }

}
