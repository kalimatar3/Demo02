using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuntipScript : MyBehaviour
{
    [SerializeField] protected Transform Target;
    protected override void Start()
    {
        base.Start();
        StartCoroutine(this.FakeUpdate());
    }
    protected IEnumerator FakeUpdate()
    {
        while(true)
        {
            Vector3 huongsung  = Target.position - this.transform.position;
            yield return this.transform.forward = huongsung;
            yield return Target.transform.forward = huongsung;
        }
    }
}
