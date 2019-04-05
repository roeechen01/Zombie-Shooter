using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    private PlayerAttack playerAttack;
    public AudioClip gunfire;

    public void Fire(Bullet bullet)
    {
        AudioSource.PlayClipAtPoint(gunfire, this.transform.position);
        Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(new Vector2(0f, 0f), false);
        Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(new Vector2(0.5f, 0.5f), false);
        Instantiate(bullet, this.transform.position, transform.rotation).CreateBullet(new Vector2(-0.5f, -0.5f), false);
        playerAttack.AmmoChange(-bullet.GetAmmoRequired() * 3);
    }

    // Use this for initialization
    void Start () {
        playerAttack = GetComponent<PlayerAttack>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
