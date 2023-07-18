using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseCoin : BufftoPlayer
{
    [SerializeField] protected Quaternion thisrotation;
    protected override void SendDametoObj(Transform obj)
    {
        PlayerReciver playerReciver =  obj.transform.GetComponent<PlayerReciver>();
        if(playerReciver == null) return;
        DataManager.Instance.IcrGold((int)dealnumber);
        StartCoroutine(DelayDeSpawn(obj));
    }
    protected IEnumerator DelayDeSpawn(Transform obj)
    {
        yield return new WaitUntil(predicate : () =>
        {
            thisrotation.z = ((int)thisrotation.z + 2) % 5 ;
            this.transform.parent.GetChild(0).rotation = thisrotation;
            this.transform.parent.Translate(Vector3.up * Time.deltaTime * 1f * 10);
            if(this.transform.parent.position.y < 5) return false;
            else return true;
        }); 
        base.SendDametoObj(obj);
    }
}