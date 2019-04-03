using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Vector3 shootDirection;
    new Rigidbody2D rigidbody2D;
    private float speed = 12;


    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        SetVelocity();
    }
    
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void SetBulletSpeed()
    {
        float x = rigidbody2D.velocity.x;
        float y = rigidbody2D.velocity.y;
        if(x!=0 || y != 0)
        {
            if (x > 1 || x < -1 || y > 1 || y < -1)
            {
                while (x > 1 || x < -1 || y > 1 || y < -1)
                {
                    x /= 1.001f;
                    y /= 1.001f;
                }
                rigidbody2D.velocity = new Vector2(x * speed, y * speed);
            }
            else
            {
                if (x < 1 && x > -1 || y < 1 && y > -1)
                {
                    while ((x < 1 && x > -1) && (y < 1 && y > -1))
                    {
                        x *= 1.001f;
                        y *= 1.001f;
                    }
                    rigidbody2D.velocity = new Vector2(x * speed, y * speed);
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }   
        
    }

    void SetVelocity()
    {
        shootDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rigidbody2D.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
        SetBulletSpeed();
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag.Equals("Zombie"))
        {
            Destroy(collider2D.gameObject);
            Destroy(gameObject);
        }
    }

}
