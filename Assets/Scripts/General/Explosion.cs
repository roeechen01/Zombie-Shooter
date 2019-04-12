using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioClip explosionClip;

    // Start is called before the first frame update
    void Start()
    {
        General.MakeSmaller(gameObject);
        Invoke("DestoryItself", 1f);
        AudioSource.PlayClipAtPoint(explosionClip, this.transform.position);
    }

    void DestoryItself()
    {
        Destroy(gameObject);
    }

    virtual protected void OnTriggerStay2D(Collider2D collider2D)
    {
        Zombie zombie = collider2D.GetComponent<Zombie>();
        if (zombie && zombie.CanHit())
            zombie.Dead();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
