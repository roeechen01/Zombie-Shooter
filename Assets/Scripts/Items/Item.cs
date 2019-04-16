using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected PlayerAttack player;
    public AudioClip audioClip;


    // Start is called before the first frame update
    void Start()
    {
        SetUpGame.MakeSmaller(gameObject);
        player = FindObjectOfType<PlayerAttack>();
        Invoke("DestroyItself", 30f);
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag.Equals("Player") && player.body == collider2D)
        {
            Ability();
            AudioSource.PlayClipAtPoint(audioClip, this.transform.position);
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
