using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperLaser : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private Sprite laser;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        laser = spriteRenderer.sprite;
    }

    public void Invisible()
    {
        spriteRenderer.sprite = null;
    }

    public void Visible()
    {
        spriteRenderer.sprite = laser;
    }
}
