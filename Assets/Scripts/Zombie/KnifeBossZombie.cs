using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeBossZombie : Boss
{
    protected override void CreateZombie()
    {
        CreateZombieTypeInfo(120, 30, 4.5f);
    }
}
