using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBossZombie : Zombie
{
    protected override void CreateZombie()
    {
        CreateZombieTypeInfo(100, 30, 3f);
        this.boss = true;
    }

    public override void HeadShot(int demage)
    {
        BulletHit(demage * 2);
    }
}
