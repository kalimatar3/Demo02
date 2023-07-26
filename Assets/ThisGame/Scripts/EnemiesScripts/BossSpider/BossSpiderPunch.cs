using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpiderPunch : EnemieAct
{
    protected void punching()
    {
        timer += Time.deltaTime;
        if(this.timer >= timerate && gate)
       {
            timer  = 0;
            gate = false;
            EnemieActSpawner.Instance.Spawn(EnemieActSpawner.ActEnum.BossPunch.ToString(),this.transform.parent.position,this.transform.parent.rotation);
       }
    }
    protected override void Action()
    {
        if(this.CanDo() && !this.gate)   this.gate = true;
        if(!this.gate) 
        {
            timer = 1.5f;
            return;
        }
        this.Doing();
    }

    protected override void Doing()
    {
        base.Doing();
        this.punching();
    }
}
