using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopCost : UIperform
{
    protected override void PreformText()
    {
        base.PreformText();
        foreach(DataManager.ShopData element in DataManager.Instance.ListShopData )
        {
            if(this.transform.parent.name == element.Name)
            {
                this.Text.text = element.Cost.ToString();
            }
        }
    }
}
