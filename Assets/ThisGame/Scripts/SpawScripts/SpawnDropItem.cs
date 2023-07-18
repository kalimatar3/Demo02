using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDropItem : MyBehaviour
{
    public List<float> ListDropRate;

    public void spawnBuff()
    {
        List<float> Element = Rand.Main(ListDropRate);
        if(Element[0] <= 0) return;
        BuffSpawner.Instance.Spawn(BuffSpawner.Instance.Buffname[(int)Element[0]],this.transform.parent.position,Quaternion.identity);
    }
}
