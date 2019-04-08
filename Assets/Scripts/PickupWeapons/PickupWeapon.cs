using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : MonoBehaviour
{
    protected Weapon weapon;
    public AudioClip pickupClip;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
            FindWeapon();
            weapon.SetUpWeapon();
            AudioSource.PlayClipAtPoint(pickupClip, this.transform.position);
        }
    }
    protected virtual void FindWeapon() { }
}
