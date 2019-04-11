using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected PlayerAttack player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerAttack>();
        Invoke("DestroyItself", 30f);
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag.Equals("Player"))
        {
            Ability();
            Destroy(gameObject);
        }
    }

    virtual protected void Ability()
    {

    }

    void DestroyItself()
    {
        Destroy(gameObject);
    }
}
