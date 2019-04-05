using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    Vector3 shootDirection;
    new Rigidbody2D rigidbody2D;
    public float speed = 12f;
    public Vector2 range = new Vector2(0, 0);



    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
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



    public void SetVelocity(Vector2 range)
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        shootDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        shootDirection += new Vector3(Random.Range(-range.x, range.x),Random.Range(-range.y, range.y) , 0f);
        rigidbody2D.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
        SetBulletSpeed();
    }

	// Update is called once per frame
	void Update () {
	}
}
