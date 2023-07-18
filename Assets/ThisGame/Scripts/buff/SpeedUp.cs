using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpeedUp : BufftoPlayer
{
    protected static SpeedUp instance;
    public static SpeedUp Instance { get => instance;}

    [SerializeField] protected float SpeedUptime;
    protected override void Awake()
    {
        base.Awake();
        if(instance != null && instance != this)
        {
            Debug.LogWarning(this.gameObject + "Existed");
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
        BuffManager.Instance.CurrentBuff = this.transform.parent;
        playerReciver.playerController.PlayerMoving.BoostValue = dealnumber;
        playerReciver.playerController.PlayerMoving.BoostTime = SpeedUptime;
        base.SendDametoObj(obj);
    }
}
