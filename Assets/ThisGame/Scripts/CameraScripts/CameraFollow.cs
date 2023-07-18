using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : followObj
{
    [SerializeField] protected Vector3 DefaultCamPOS,FireCamPOS,BossCamPOS;
    [SerializeField] protected Quaternion DefaultCamROS;
    protected override void Start()
    {
        base.Start();
        this.Forcus(this.transform.parent,0.2f);
    }
    protected override void follow()
    {
        if(Obj == null) return;
        if(Obj == PlayerController.Instance.transform)
        {
            Vector3 newPos = Vector3.Lerp(this.transform.parent.position, Obj.transform.position + DefaultCamPOS , this.smooth * Time.deltaTime);
            this.transform.parent.position = newPos;
            if(InputManager.Instance.Shootingstick.Horizontal !=0 ||InputManager.Instance.Shootingstick.Vertical != 0)
            {
                Vector3 NewPOs =  Vector3.Lerp(this.transform.parent.position, Obj.transform.position + FireCamPOS,smooth /2 * Time.deltaTime);
                this.transform.parent.position = NewPOs;
            }
        }
        else
        {
            this.ForcustoBoss();
        }
    }
    protected virtual void ForcustoBoss()
    {
        Vector3 Direction = (Obj.transform.position - this.transform.parent.position).normalized;
        this.transform.parent.forward = Direction;
    }
    public virtual void Forcus(Transform obj,float time)
    {
        StartCoroutine(this.Forcusing(obj,time));
    }
    protected  IEnumerator Forcusing(Transform obj,float time)
    {
        this.Obj = obj;
        yield return new WaitForSeconds(time);
        this.Obj = PlayerController.Instance.transform;
        this.transform.parent.rotation = DefaultCamROS;
    }
}
