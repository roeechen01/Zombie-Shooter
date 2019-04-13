using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeBossZombie : Zombie
{
    private Slider slider;

    new void Start()
    {
        base.Start();
        slider = FindObjectOfType<Slider>();
        slider.maxValue = this.life;
        slider.value = this.life;       
    }

    protected override void CreateZombie()
    {
        CreateZombieTypeInfo(100, 30, 3f);
        this.boss = true;
    }

    public override void HeadShot(int demage)
    {
        Hit(demage * 2);
    }

    public override void Hit(int demage)
    {
        base.Hit(demage);
        UpdateSlider();
    }

    void UpdateSlider()
    {
        InvokeRepeating("SliderFlow", 0f, 0.005f);
    }

    void SliderFlow()
    {
        slider.value -= 0.02f;
        if(slider.value <= this.life)
        {
            slider.value = this.life;
            CancelInvoke("SliderFlow");
        }
        if (slider.value <= 0)
            base.Dead();
    }

    public override void Dead()
    {
        //base.Dead();
    }


}
