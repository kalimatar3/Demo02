using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MyBehaviour
{
    protected static LevelManager instance;
    public static LevelManager Instance { get => instance;}

    [SerializeField] protected List<Transform> Listlevels;
    protected float timer;
    [SerializeField] protected int CurrentLevel;
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
                SpawnEnemies spawnEnemies = level.GetComponent<SpawnEnemies>();
                if(spawnEnemies == null) return;
                CEinCrlevel = spawnEnemies.AllEnemieinlevel;
                NEinCrlevel = spawnEnemies.MaxNumberofEnemies;
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
            foreach(Transform element in Listlevels)  element.gameObject.SetActive(false);
            Listlevels[CurrentLevel].gameObject.SetActive(true);
            CurrentLevel ++;
            if(CurrentLevel >= Listlevels.Count)PanelCtrl.Instance.ShowPanel("Winpannel");
        }
    }
    protected void FixedUpdate()
    {
        this.ChangeLvInEmty();
    }
}
