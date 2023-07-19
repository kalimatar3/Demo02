using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerReciver : DameReciver
{
    public PlayerController playerController;
    [SerializeField] protected float InvulnerableNumber;
    [SerializeField] protected float CurinvulnerableNumber;
    [SerializeField] protected bool CanRevise;
    [SerializeField] protected float timer,delaytime;
    protected bool PanelGate,CanTakeDame;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
        CanRevise = true;
    }
    protected override void Start()
    {
        base.Start();
        StartCoroutine(this.TakeDameDelay());
    }
    protected void LoadPlayerCtrl()
    {
        if(playerController != null) return;
        playerController = GetComponentInParent<PlayerController>();
        if(playerController == null ) Debug.LogWarning(this.transform + "can find playerCtrl");
    }
    public void canRevise()
    {
        CanRevise = false;
    }
    protected override void Dead()
    {
        if( this.CurrentHp <= 0)
        {
            if(CanRevise)
            {
                if(!PanelGate)
                {
                    PanelGate = true;
                    PanelCtrl.Instance.ShowPanel("RevivePannel");
                    PanelCtrl.Instance.HirePanel("GameplayPanel");
                }
            }
            if(!CanRevise)
            {
                ButtonScript.Instance.Replay();
            }
        } 
    }
    public override void  ReBorn()
    {
        this.MaxHp = playerController.playerSO.PlayerUpgrade[DataManager.Instance.GetUpgradenumberfromUGAD(DataManager.UpgradeabledataName.IcreMaxHPCost.ToString())].MaxHp;
        base.ReBorn();
    }
    public virtual void invulnerable()
    {
        CurinvulnerableNumber = InvulnerableNumber;  
    }
    public override void DeductHp(float dame)
    {
        if(CanTakeDame)
        {
            CanTakeDame = false;
            timer = 0;
            if(CurinvulnerableNumber > 0)
            {
                CurinvulnerableNumber --;
            }
            else
            {
                PanelCtrl.Instance.ShowPanel("TakeDamePanel");
                SoundSpawner.Instance.Spawn(CONSTSoundsName.Attacked,Vector3.zero,Quaternion.identity);
                base.DeductHp(dame);
            }
        StartCoroutine(TakeDameDelay());
        }
    }
    protected IEnumerator TakeDameDelay()
    {
        while(CanTakeDame == false)
        {
            yield return timer += Time.deltaTime * 1f;
            if(timer > delaytime) 
            {
                CanTakeDame = true;
            }
        }
    }
}
