using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIperform : MyBehaviour
{
    [SerializeField] protected Text Text;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTexMeshPro();
    }
    protected void LoadTexMeshPro()
    {
        if(Text!= null) return;
        this.Text = GetComponent<Text>();
    }
    protected virtual void PreformText()
    {
    }
    protected virtual void FixedUpdate()
    {
        this.PreformText();
    }
}
