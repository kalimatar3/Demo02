using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : Spawner
{
    protected static EffectSpawner instance;
    public static EffectSpawner Instance { get => instance ;}
    [SerializeField] protected List<string> Bulletname;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletName();
    }
    protected void LoadBulletName()
    {
        for(int  i = 0 ; i < prefabs.Count; i++)
        {
            if(Bulletname.Count < prefabs.Count) Bulletname.Add("");
            Bulletname[i] = prefabs[i].name;
        }
    }
    protected override void Awake()
    {
        base.Awake();
        if(instance != this && instance != null) Destroy(this);
        else instance = this;
    }
}
