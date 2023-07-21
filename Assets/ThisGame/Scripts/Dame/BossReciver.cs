using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossReciver : EnemiesReciver
{
    protected override void Dying()
    {
        SoundSpawner.Instance.Spawn(CONSTSoundsName.BossDead,this.transform.position,Quaternion.identity);
        base.Dying();
    }
}
