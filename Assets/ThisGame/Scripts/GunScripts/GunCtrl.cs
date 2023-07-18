using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCtrl : MyBehaviour
{
    protected static GunCtrl instance;
    public static GunCtrl Instance { get => instance ;}
    [SerializeField] protected Shooting shooting;
    public List<Transform> ListGuns;
    public List<GunsSO> ListGunSO;
    public int number;
    public Shooting Shooting { get => shooting;}
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShooting();
        this.LoadPrefabs();
        this.LoadGunSO();
    }
    protected void Update()
    {
        this.ActiveGun();
    }
    protected virtual void LoadPrefabs()
    {
        if(ListGuns.Count > 0)  return;
        Transform Prefabs = transform.Find("Prefabs");
        foreach(Transform Pre in Prefabs)
        {
            this.ListGuns.Add(Pre);
        }
    }
    public void ChangeWepon()
    {
        number  = (number +1) % ListGuns.Count;
    }
    protected virtual void LoadShooting()
    {
        if(shooting != null) return;
        shooting = GetComponentInChildren<Shooting>();
    }
    protected virtual void ActiveGun()
    {
        if(number > ListGuns.Count - 1)  number = ListGuns.Count-1;
        if(number< 0) number = 0;
        foreach(Transform gun in  ListGuns)
        {
            gun.gameObject.SetActive(false);
        }
        ListGuns[number].gameObject.SetActive(true);
    }
    protected override void Awake()
    {
        base.Awake();
        if(instance != this && instance != null) Destroy(this);
        else instance = this;
    }
    protected virtual void LoadGunSO()
    {
        if(ListGunSO.Count > 0) return;
        Transform Pre = transform.Find("Prefabs");
        if(Pre == null) return;
        foreach(Transform GunName in Pre)
        {
        string rePath = "Guns/" + GunName.name;
        ListGunSO.Add(Resources.Load<GunsSO>(rePath));
        Debug.Log( this.transform.name  + " LoadSO");
        }
    }
}
