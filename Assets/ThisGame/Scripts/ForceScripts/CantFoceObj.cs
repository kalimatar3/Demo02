using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantFoceObj : MyBehaviour
{
    [SerializeField] protected Vector3 test;
    [SerializeField] protected Rigidbody Thisbody;
    [SerializeField] protected EnemieCtrl enemieCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRig();
        this.LoadEnemiesCtrl();
    }
    protected void LoadRig()
    {
        if(Thisbody != null) return;
        Thisbody = GetComponent<Rigidbody>();
    }
    protected void LoadEnemiesCtrl()
    {
        if(enemieCtrl != null) return;
        enemieCtrl = GetComponent<EnemieCtrl>();
    }
    protected void  FixedUpdate()
    {
        test= Thisbody.velocity;
        if(Thisbody.velocity.magnitude <= 0)
        {
        enemieCtrl.TrackPlayer.gameObject.SetActive(true);     
        }
        else
        {
            Thisbody.velocity = Vector3.zero;
        }
    }
    void OnCollisionStay(Collision other)
    {
        EnemieCtrl enemieCtrl = other.transform.GetComponent<EnemieCtrl>();
        if(enemieCtrl == null) return;
        enemieCtrl.TrackPlayer.gameObject.SetActive(false);
    }
    protected void OnCollisionExit(Collision other)
    {
    }
}
