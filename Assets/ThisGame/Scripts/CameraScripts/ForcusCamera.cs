using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcusCamera : MyBehaviour
{
    [SerializeField] CameraFollow cameraFollow;
    protected override void Start()
    {
        base.Start();
        StartCoroutine(this.DelayStart());
    }
    protected IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(0.5f);
        cameraFollow.Forcus(this.transform.parent,3f);
    }
}
