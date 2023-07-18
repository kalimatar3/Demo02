using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerDeal : DealToPlayer
{
    [SerializeField] protected float timerate;
    protected float timer;
    protected void OnTriggerStay(Collider other)
    {
        timer += Time.deltaTime * 1f;
        if(timer > timerate)
        {
            timer = 0;
            this.SendDametoObj(other.transform);
        }
    }
}
