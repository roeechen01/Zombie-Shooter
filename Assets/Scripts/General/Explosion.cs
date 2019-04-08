﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioClip explosionClip;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestoryItself", 1f);
        AudioSource.PlayClipAtPoint(explosionClip, this.transform.position);
    }

    void DestoryItself()
    {
        Destroy(gameObject);
    }

    virtual protected void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag.Equals("Zombie"))
        {
            Zombie zombie = collider2D.gameObject.GetComponent<Zombie>();
            Destroy(zombie.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}