using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSlider : BaseSlider
{
    protected void ShowEnemiesSlider()
    {
        if(LevelManager.Instance.NEinCrlevel != 0)
        {
            float number =   (float)LevelManager.Instance.CEinCrlevel/(float)LevelManager.Instance.NEinCrlevel;
            Slider.value = number;
        }
    }
    protected void FixedUpdate()
    {
        this.ShowEnemiesSlider();
    }
}
