using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MyBehaviour
{
    protected static ButtonScript instance;
    public static ButtonScript Instance { get => instance;}
    public List<RectTransform> ListUnlockbutton;
    public List<RectTransform> ListSelectButton;
    public RectTransform Currentbutton;
    public RectTransform SelectButtonFrame;
    public Transform Canselectbutton;
    public Transform BuyButton;
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
    public void Showpanel(string panelname)
    {
        PanelCtrl.Instance.ShowPanel(panelname);
    }
    public void HirePanel(string Panelname)
    {
        PanelCtrl.Instance.HirePanel(Panelname);
    }
    public void ClearData()
    {
        Lsmanager.Instance.ClearData();
    }
    public void UpdatePlayer()
    {
        DataManager.Instance.IcrMaxHp();
        this.Reborn();
    }
    public void UpdateGun()
    {
        DataManager.Instance.IcrMaxbullet();
        this.Reborn();
    }
    public void UpdateCoin()
    {
        DataManager.Instance.IcrCoinEarn();
    }
    public void Reborn()
    {
        GunCtrl.Instance.Shooting.reborn();
        PlayerController.Instance.PlayerReciver.ReBorn();
    }
    public void Revive()
    {
        PlayerController.Instance.PlayerReciver.canRevise();
        SoundSpawner.Instance.Spawn(CONSTSoundsName.Revive,Vector3.zero,Quaternion.identity);
        this.Reborn();
    }
    public void Replay()
    {
        PlayerController.Instance.PlayerReciver.Replay();
    }
    public void Reload()
    {
        GunCtrl.Instance.Shooting.Reloading();
    }
    public void ChangeWepon()
    {
        GunCtrl.Instance.ChangeWepon();
    }
    public void LoadMap(Transform obj)
    {
        DataManager.Instance.CurrentMap = DataManager.Instance.GetReferanceName(obj);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Lsmanager.Instance.SaveGame();
    }
    public void LoadPlaeyrModel(Transform obj)
    {
        DataManager.Instance.CurrentModelName = DataManager.Instance.GetReferanceName(obj);
    }
    public void Select()
    {
        Lsmanager.Instance.SaveGame();
        ModelManager.Instance.ActiveModel();
    }
    public void Buy()
    {
        DataManager.Instance.Unlock(Currentbutton);
        foreach(DataManager.ShopData element in DataManager.Instance.ListShopData)
        {
            if(Currentbutton.name == element.Name)
            {
                Currentbutton.gameObject.SetActive(!element.Available);
            }
        }
        Lsmanager.Instance.SaveGame();
    }
    public void OneLick(Transform thisTrans)
    {
       thisTrans.gameObject.SetActive(false);
    }
    public void InvulnerablePlayer()
    {
        SoundSpawner.Instance.Spawn(CONSTSoundsName.Invulnerable,Vector3.zero,Quaternion.identity);
        PlayerController.Instance.PlayerReciver.invulnerable();
    }
    public void  GetCurrentButton(RectTransform obj)
    {
        SoundSpawner.Instance.Spawn(CONSTSoundsName.ButtonTap,Vector3.zero,Quaternion.identity);
        if(!obj.gameObject.activeInHierarchy)
        {
            this.Currentbutton = null;
            return;
        }
        this.Currentbutton = obj;
    }
    protected void FollowCurrentButton()
    {
        if(Currentbutton == null) return;
        this.BuyButtonState();
        this.SelectButtonState();
    }
    protected void BuyButtonState()
    {
        foreach(Transform locked in ListUnlockbutton)
        {
            if(locked.name == Currentbutton.name)
            {
                SelectButtonFrameState();
                BuyButton.gameObject.SetActive(locked.gameObject.activeInHierarchy);
                return;
            }
        }
        BuyButton.gameObject.SetActive(false);
    }
    protected void SelectButtonFrameState()
    {
        SelectButtonFrame.transform.position = Currentbutton.transform.position;
        SelectButtonFrame.transform.gameObject.SetActive(Currentbutton.gameObject.activeInHierarchy);
        SelectButtonFrame.sizeDelta =  Currentbutton.sizeDelta + new Vector2(1,1);
    }
    protected void SelectButtonState()
    {
        foreach(Transform locked in ListSelectButton)
        {
            if(locked.name == Currentbutton.name)
            {
               SelectButtonFrameState();
                Canselectbutton.gameObject.SetActive(locked.gameObject.activeInHierarchy);
                return;
            }
        }
        Canselectbutton.gameObject.SetActive(false);
    }
    protected void FixedUpdate()
    {
        this.FollowCurrentButton();
    }
}
