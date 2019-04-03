using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : Bullet {



    // Use this for initialization
    void Start () {
        demage = 1;
        speed = 12f;
        gameObject.AddComponent<BulletController>();
        GetComponent<BulletController>().speed = this.speed;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
