using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunrotation : MyBehaviour
{
    protected void RotateGun()
    {
        if(InputManager.Instance.Shootingstick.Horizontal != 0 || InputManager.Instance.Shootingstick.Vertical != 0 )
        this.transform.rotation = Quaternion.LookRotation(new Vector3(InputManager.Instance.Shootingstick.Horizontal,0,InputManager.Instance.Shootingstick.Vertical));
        else
        {
            this.transform.rotation = PlayerController.Instance.transform.rotation;
        }
    }
    protected void FixedUpdate()
    {
        this.RotateGun();
    }
}
