using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : MonoBehaviour
{
    protected Weapon weapon;
    public AudioClip pickupClip;

    void SelfDestroy()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        SetUpGame.MakeSmaller(gameObject);
        Invoke("SelfDestroy", 30f);
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag.Equals("Player") && collider2D == collider2D.gameObject.GetComponent<PlayerAttack>().body)
        {
            Destroy(gameObject);
            FindWeapon();
            if (weapon.gameObject.GetComponent<PlayerAttack>().GetWeapon() == weapon)
                weapon.SetUpWeapon(true);
            else weapon.SetUpWeapon(false);
            AudioSource.PlayClipAtPoint(pickupClip, this.transform.position);
        }
    }
    protected virtual void FindWeapon() { }
}
