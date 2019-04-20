using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Explosion explosion;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Boom", 2f);
    }

    void Boom()
    {
        Instantiate(explosion, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
