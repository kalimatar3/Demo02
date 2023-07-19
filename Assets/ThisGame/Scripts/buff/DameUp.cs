using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameUp : BufftoPlayer
{   
    protected static DameUp instance;
    public static DameUp Instance { get => instance;}
    [SerializeField] protected float DameUptime;
    protected override void Awake()
    {
        base.Awake();
        if(instance != null && instance != this)
        {
            //
        }
        else instance = this;
    }
    protected void OnEnable()
    {
        if(instance != this && instance.transform.parent.gameObject.activeInHierarchy) Destroy(this.transform.parent.gameObject);
    }
    protected override void SendDametoObj(Transform obj)
    {
        PlayerReciver playerReciver =  obj.transform.GetComponent<PlayerReciver>();
        if(playerReciver == null) return;
        BuffManager.Instance.CurrentBuff =this.transform.parent;
        playerReciver.playerController.GunCtrl.Shooting.BoostValue = this.dealnumber;
        playerReciver.playerController.GunCtrl.Shooting.BoostTime = this.DameUptime;
        SoundSpawner.Instance.Spawn(CONSTSoundsName.DameUp,Vector3.zero,Quaternion.identity);
        base.SendDametoObj(obj);
    }
}
