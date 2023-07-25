using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrackPlayer : MyBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float stopDis;
    [SerializeField] protected NavMeshAgent thisNav; 
    public bool Tracking;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadthisNav();
    }
    protected void LoadthisNav()
    {
        thisNav = GetComponentInParent<NavMeshAgent>();
        if(thisNav == null) return;
    }
    protected virtual void Track()
    {
        Vector3 Direction = (PlayerController.Instance.transform.position - this.transform.parent.position).normalized;
        float Distance =  (PlayerController.Instance.transform.position - this.transform.parent.position).magnitude;
        if(Distance > stopDis) 
        {
            Tracking = true;
            thisNav.SetDestination(PlayerController.Instance.transform.position);
            thisNav.speed = speed;
        }
        else 
        {
            thisNav.SetDestination(this.transform.parent.position);
            this.transform.parent.LookAt(PlayerController.Instance.transform);
            Tracking = false;
        }
    }
    protected void FixedUpdate()
    {
        this.Track();
    }
}
