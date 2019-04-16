using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Zombie
{
    private Slider slider;
    private bool flowing = false;

    new void Start()
    {
        base.Start();
        slider = FindObjectOfType<Slider>();
        slider.maxValue = this.life;
        slider.value = this.life;
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
        InvokeRepeating("SliderFlow", 0f, 0.0050f);
    }

    void SliderFlow()
    {
        flowing = true;
        slider.value -= 0.1f;
        if (slider.value <= this.life)
        {
            slider.value = this.life;
            CancelInvoke("SliderFlow");
            flowing = false;
        }
        if (slider.value <= 0)
        {
            slider.maxValue = 0;
            base.Dead();
        }
    }

    new void Update()
    {
        base.Update();
        if (!flowing)
            slider.value = this.life;
    }

    public override void Dead() { }
}
