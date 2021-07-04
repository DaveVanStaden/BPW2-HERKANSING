using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUp : ItemTemplate
{
    public override void ActivatePower()
    {
        base.ActivatePower();
        stats.damage.baseValue += 10;
    }
}
