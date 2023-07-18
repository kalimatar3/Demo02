using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hpbar : BaseSlider
{
    [SerializeField] public Transform DameReciver;
    [SerializeField] protected float CurrentHp,MaxHp;
    protected Text Hpnumber;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextMesh();
    }
    protected void LoadTextMesh()
    {
        Text Hpnumber = this.transform.GetComponentInChildren<Text>();
        if(Hpnumber == null) Debug.LogWarning(this.transform + "Can't Found TextMesh");
        this.Hpnumber = Hpnumber;
    }
    protected virtual void ShowHp()
    {
        float HpPercent = CurrentHp/MaxHp;
        this.Hpnumber.text = (((int)CurrentHp).ToString());
        this.Slider.value = HpPercent;
    }
    protected void FixedUpdate()
    {
        this.ShowHp();
    }
}
