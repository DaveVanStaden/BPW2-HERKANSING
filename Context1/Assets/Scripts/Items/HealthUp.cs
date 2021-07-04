using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : ItemTemplate
{
    public override void ActivatePower()
    {
        base.ActivatePower();
        stats.Health += 20;
        stats.SetHealth();
    }
}
