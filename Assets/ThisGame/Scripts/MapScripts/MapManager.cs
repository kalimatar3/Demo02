using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MyBehaviour
{
    protected static MapManager instance;
    public static MapManager Instance { get => instance ;}
    public List<Vector3> ListBossSapwnPos;
    protected override void Awake()
    {
        base.Awake();
        if(instance != this && instance != null) Destroy(this);
        else instance = this;
    }
    protected override void LoadComponents()
    {
       base.LoadComponents();
    }
    public void LoadMap(string Mapname)
    {
        string path = "Maps/" + Mapname;
        if(Resources.Load<Transform>(path) == null) Debug.LogWarning(this.transform + "Can load Resources " + Mapname);
        Transform thisMap = Instantiate(Resources.Load<Transform>(path));
        Transform bossspawnPos = thisMap.transform.Find("BossSpawnPos");
        foreach(Transform element in bossspawnPos)
        {
            ListBossSapwnPos.Add(element.position);
        }
    }
    protected override void Start()
    {
        base.Start();
        this.LoadMap(DataManager.Instance.CurrentMap);
    }
}
