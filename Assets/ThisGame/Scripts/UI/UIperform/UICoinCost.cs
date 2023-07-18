using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICoinCost : UIperform
{
   protected override void PreformText()
    {
        base.PreformText();
        string Mes = DataManager.Instance.GetCost(DataManager.UpgradeabledataName.IcreCoinCost.ToString()).ToString();
        Text.text = Mes;
    }
}
