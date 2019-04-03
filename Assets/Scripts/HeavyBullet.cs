using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBullet : Bullet {

    // Use this for initialization
    void Start () {
        demage = 2;
        speed = 8f;
        gameObject.AddComponent<BulletController>();
        GetComponent<BulletController>().speed = this.speed;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
