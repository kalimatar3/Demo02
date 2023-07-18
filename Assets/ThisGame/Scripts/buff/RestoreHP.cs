using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreHP : BufftoPlayer
{
    protected override void SendDametoObj(Transform obj)
    {
        PlayerReciver playerReciver =  obj.transform.GetComponent<PlayerReciver>();
        if(playerReciver == null) return;
        playerReciver.RestoreHp(this.dealnumber);
        base.SendDametoObj(obj);
    }
}
