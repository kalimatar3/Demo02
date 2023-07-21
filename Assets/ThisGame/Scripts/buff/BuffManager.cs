using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MyBehaviour
{    
    protected static BuffManager instance;
    public static BuffManager Instance { get => instance ;}
    public Transform CurrentBuff,CurrentBuffEffect;
    protected override void Awake()
    {
        base.Awake();
        if(instance != null && instance != this)
        {
            Destroy(this);
            Debug.LogWarning(this.gameObject + "Existed");
        }
        else instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCurrentBuff();
    }
    protected void LoadCurrentBuff()
    {
        this.CurrentBuff = this.transform.parent;
    }
}
