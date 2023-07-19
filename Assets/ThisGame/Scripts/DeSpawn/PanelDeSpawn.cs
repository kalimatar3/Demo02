using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDeSpawn : Despawnbytime
{
    protected override void DeSpawnObjects()
    {
        PanelCtrl.Instance.HirePanel(this.transform.name);
    }
}
