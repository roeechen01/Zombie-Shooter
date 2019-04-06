using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    protected PlayerAttack playerAttack;
    public AudioClip gunfire;
    protected Bullet bullet;
    protected int shotsNumber;

    public bool CanFire(int ammo)
    {
        return ammo >= shotsNumber;
    }

    public virtual void Fire()
    {

    }

    public void SetPlayerAttack(PlayerAttack playerAttack)
    {
        this.playerAttack = playerAttack;
    }

    protected int GetAmmoRequired()
    {
        return bullet.GetAmmoRequired() * shotsNumber;
    }
}
