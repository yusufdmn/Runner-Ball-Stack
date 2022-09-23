using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraUpUIObject : PowerUpUIObject
{
    [SerializeField] ExtraUpManager extraUpManager;

    public override void Upgrade()
    {
        base.Upgrade();
        extraUpManager.AddExtraOneBall();
    }
}
