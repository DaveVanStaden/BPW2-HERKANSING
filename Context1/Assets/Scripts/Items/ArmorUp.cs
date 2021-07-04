using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorUp : ItemTemplate
{
    public override void ActivatePower()
    {
        base.ActivatePower();
        if(stats.armor.baseValue < 50)
        {
            stats.armor.baseValue += 5;
        }
    }
}
