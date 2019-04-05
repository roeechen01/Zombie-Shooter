using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleZombie : Zombie {

    new private int life = 2;
    new private int demage = 1;
    new private float speed = 2f;

	// Use this for initialization
	void Start () {
        CreateZombieTypeInfo(life, demage, speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
