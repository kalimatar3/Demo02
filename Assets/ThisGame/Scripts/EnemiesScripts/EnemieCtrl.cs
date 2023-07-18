using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieCtrl : MyBehaviour
{
    [SerializeField] protected TrackPlayer trackPlayer;
    public TrackPlayer TrackPlayer {get => trackPlayer;}
    [SerializeField] protected SpawnDropItem spawnDropItem;
    public SpawnDropItem SpawnDropItem => spawnDropItem;
    [SerializeField] protected EnemiesReciver enemiesReciver;
    public EnemiesReciver EnemiesReciver => enemiesReciver;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrackPlayer();
        this.LoadSpawnDropItem();
        this.LoadEnemieReciver();
    }
    protected void LoadTrackPlayer()
    {
        if(trackPlayer != null) return;
        this.trackPlayer = this.transform.GetComponentInChildren<TrackPlayer>();
        Debug.LogWarning(this.transform.name + "Load TrackPlayer",gameObject);
    }
    private void LoadEnemieReciver()
    {
        if(enemiesReciver != null) return;
        this.enemiesReciver = this.transform.GetComponentInChildren<EnemiesReciver>();
        Debug.LogWarning(this.transform.name + "Load TrackPlayer",gameObject);
    }
    protected void LoadSpawnDropItem()
    {
        if(SpawnDropItem != null) return;
        this.spawnDropItem = this.transform.GetComponentInChildren<SpawnDropItem>();
       Debug.LogWarning(this.transform.name + "Load SpawnDropItem",gameObject);
    }
}
