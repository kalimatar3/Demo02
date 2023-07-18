using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIReload : UIperform
{
    protected override void PreformText()
    {
        base.PreformText();
        this.Text.text = (PlayerController.Instance.GunCtrl.Shooting.reloadtimer.ToString());
    }
}
