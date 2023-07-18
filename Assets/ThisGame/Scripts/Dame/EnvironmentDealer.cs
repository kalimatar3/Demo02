using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentDealer : DealToEnemies
{
    protected override void SendDametoObj(Transform obj)
    {
        EnemiesReciver enemiesReciver =  obj.transform.GetComponent<EnemiesReciver>();
        if(enemiesReciver == null) return;
        EnemiesSpawner.Instance.ListEnemiesDefectSpawn.Add(obj.transform.parent);
        EnemiesSpawner.Instance.DeSpawnToPool(obj.transform.parent);
    }
}
