using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealToPlayer : DameDealer
{
    protected override void SendDametoObj(Transform obj)
    {
        PlayerReciver playerReciver =  obj.transform.GetComponent<PlayerReciver>();
        if(playerReciver == null) return;
        playerReciver.DeductHp(this.dealnumber);
        base.SendDametoObj(obj);
    }
}
