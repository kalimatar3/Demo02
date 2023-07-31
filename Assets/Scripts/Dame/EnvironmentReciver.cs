using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentReciver : DameReciver
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.MaxHp = 100000000;
    }
}
