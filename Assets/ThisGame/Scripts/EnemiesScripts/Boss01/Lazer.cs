using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : EnemieAct
{
    [SerializeField] protected float PreShootTime,ShootingTime;
    [SerializeField] protected LayerMask PlayerLayer;
    [SerializeField] protected Transform TarGet;
    protected Transform DamePoint;
    protected LineRenderer LineRenderer;
    protected RaycastHit obj;
    protected float Shoottimer;
    protected bool lazergate;
    protected bool test;
    protected override void Start()
    {
        base.Start();
        LineRenderer = GetComponent<LineRenderer>();
    }
    protected void LockTarget()
    {
        this.TarGet.parent.position = PlayerController.Instance.transform.position;
    }
    protected void lazering()
    { 
        LineRenderer.positionCount = 2;
        Vector3 Origin = this.transform.position;
        Vector3 Direction = (TarGet.transform.position - Origin);
        LineRenderer.SetPosition(0,Origin);
        if(Physics.Raycast(Origin,Direction,out obj,Direction.normalized.magnitude * 50f,PlayerLayer))
        {
            LineRenderer.SetPosition(1,obj.point);
            if(lazergate)
            {
                SoundSpawner.Instance.Spawn(CONSTSoundsName.Lazer,Vector3.zero,Quaternion.identity);
                lazergate = false;
                this.DamePoint =  EnemieActSpawner.Instance.Spawn(EnemieActSpawner.ActEnum.LazerHit.ToString(),obj.point,Quaternion.identity);
                DamePoint.GetComponentInChildren<DespawnLazerHit>().Obj = this.transform.parent;
            }
            DamePoint.position = obj.point;
       }
    }
    protected void TimeController()
    {
        if(timer <= timerate) 
        {
            Shoottimer = 0;
            this.LineRenderer.positionCount = 0 ;
            if(DamePoint != null) EnemieActSpawner.Instance.DeSpawnToPool(this.DamePoint);
        } 
        if(gate) timer += Time.deltaTime * 1f;
        if(timer > timerate)
        {
            Shoottimer += Time.deltaTime * 1f;
        }   
        if(Shoottimer >= 0 && Shoottimer < PreShootTime)
        {
            lazergate = true;
            this.LockTarget();
        }
        else if(Shoottimer >= PreShootTime && Shoottimer < PreShootTime + ShootingTime)
        {
            this.lazering();
        }
        else 
        {
            gate = false;
            timer = 0;
        }
    }
    protected override void Action()
    {
        this.TimeController();
        base.Action();
    }    
}
