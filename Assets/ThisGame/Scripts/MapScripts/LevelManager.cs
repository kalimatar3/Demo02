using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MyBehaviour
{
    protected static LevelManager instance;
    public static LevelManager Instance { get => instance;}

    [SerializeField] protected List<Transform> Listlevels;
    protected float timer;
    [SerializeField] protected float preparetime;
    public int CEinCrlevel,NEinCrlevel;
    public string CrLevelname;
    protected override void Awake()
    {
        base.Awake();
        if(instance != null && instance != this)
        {
            Destroy(this);
            Debug.LogWarning(this.gameObject + "Does Existed");
        }
        else instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.Loadlevels();
    }
    protected void Loadlevels()
    {
        if(Listlevels.Count != 0 ) return;
        foreach(Transform level in this.transform)
        {
            Listlevels.Add(level);
        }
    }
    protected virtual void ChangeLvInEmty()
    {
        foreach(Transform level in Listlevels)
        {
            if(level.gameObject.activeInHierarchy)
            {
                this.CrLevelname = level.name;
                CEinCrlevel = level.GetComponent<SpawnEnemies>().AllEnemieinlevel;
                NEinCrlevel = level.GetComponent<SpawnEnemies>().MaxNumberofEnemies;
                if(CEinCrlevel > 0) return;
                if(level.GetComponent<SpawnEnemies>() == null) return;
               foreach(Transform enemie in level.GetComponent<SpawnEnemies>().ListEnemies)
                if(enemie.gameObject.activeInHierarchy == true)  return;
            }
        }
        timer += Time.deltaTime * 1f;
        if(timer > preparetime)
        {
            timer = 0;
            this.ChangeLv();
        }
    }
    protected void ChangeLv()
    {
        for(int i = 0; i < Listlevels.Count ; i++)
        {
            if(!Listlevels[(i + 1) % (Listlevels.Count)].gameObject.activeInHierarchy && Listlevels[i].gameObject.activeInHierarchy) 
            {
                Listlevels[(i + 1) % (Listlevels.Count)].gameObject.SetActive(true);
                Listlevels[i].gameObject.SetActive(false);
                Debug.Log(Listlevels[(i + 1) % (Listlevels.Count)].ToString() + " Start ");
                return;
            } 
        }
    }
    protected void FixedUpdate()
    {
        this.ChangeLvInEmty();
    }
}
