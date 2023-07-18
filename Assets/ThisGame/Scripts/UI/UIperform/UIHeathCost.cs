using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHeathCost : UIperform
{
    protected override void PreformText()
    {
        base.PreformText();
        string Mes = DataManager.Instance.GetCost(DataManager.UpgradeabledataName.IcreMaxHPCost.ToString()).ToString();
        Text.text = Mes;
    }
}
