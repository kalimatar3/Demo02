using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MyBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float stopDis;
    [SerializeField] protected Rigidbody thisBody;
    public bool Tracking;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRig();
    }
    protected void LoadRig()
    {
        if(thisBody != null) return;
        thisBody = GetComponentInParent<Rigidbody>();
    }
    protected virtual void Track()
    {
        Vector3 Direction = (PlayerController.Instance.transform.position - this.transform.parent.position).normalized;
        float Distance =  (PlayerController.Instance.transform.position - this.transform.parent.position).magnitude;
        if(Distance >= stopDis) 
        {
            Tracking = true;
            thisBody.velocity  = new Vector3(Direction.x * speed,thisBody.velocity.y,Direction.z * speed);
            this.transform.parent.LookAt(PlayerController.Instance.transform);
        }
        else 
        {
            thisBody.velocity = Vector3.zero;
            Tracking = false;
        }
    }
    protected void FixedUpdate()
    {
        this.Track();
    }
}
