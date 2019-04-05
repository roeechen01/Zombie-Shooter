using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    protected int life;
    protected int demage;
    protected float speed;

    // Use this for initialization
    void Start () {
	}

    protected void CreateZombieTypeInfo(int life, int demage, float speed)
    {
        this.life = life;
        this.demage = demage;
        this.speed = speed;
        AddZombieController();
        
    }

    private void AddZombieController()
    {
        gameObject.AddComponent<ZombieController>();
        GetComponent<ZombieController>().speed = this.speed;
    }

    public void BulletHit(int demage)
    {
        life -= demage;
        if (life <= 0)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
