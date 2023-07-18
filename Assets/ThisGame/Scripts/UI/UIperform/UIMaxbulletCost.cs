using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMaxbulletCost : UIperform
{
    protected override void PreformText()
    {
        base.PreformText();
        string Mes = DataManager.Instance.GetCost(DataManager.UpgradeabledataName.IcreMaxbulletPistolCost.ToString()).ToString();
        Text.text = Mes;
    }
}
