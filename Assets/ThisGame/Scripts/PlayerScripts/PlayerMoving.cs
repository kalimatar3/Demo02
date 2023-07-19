using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMoving : MyBehaviour
{
[SerializeField] protected Rigidbody Mybody; 
[SerializeField] protected float DefaultPlayerMovingSpeed;
[SerializeField] protected float FirePLayerMovingSpeed;
[SerializeField] protected PlayerController playerController;
[HideInInspector] public Vector3 Move; 
[HideInInspector] public float BoostValue,BoostTime;
[SerializeField] protected float CurrentSpeed;
protected float Timer,ExtraSpeed,soundtimer;
public bool CanSpeedUp;
    protected virtual void Moving()
    {
        soundtimer += Time.deltaTime * 1f;
        CurrentSpeed = DefaultPlayerMovingSpeed * ( 1 + ExtraSpeed);
        this.Move = new Vector3 (InputManager.Instance.MovingJoystick.Horizontal * CurrentSpeed, this.Mybody.velocity.y , InputManager.Instance.MovingJoystick.Vertical * CurrentSpeed);
        this.Mybody.velocity = Move;
        if(Move.magnitude >= 1 && soundtimer > 0.4f)
        {
            soundtimer = 0;
             SoundSpawner.Instance.Spawn(CONSTSoundsName.PlayerMoving,Vector3.zero,Quaternion.identity);
        } 
        if(InputManager.Instance.MovingJoystick.Horizontal != 0 || InputManager.Instance.MovingJoystick.Vertical != 0)
        {
            CurrentSpeed = FirePLayerMovingSpeed * (1 + ExtraSpeed);
            this.transform.parent.rotation =  Quaternion.LookRotation(Mybody.velocity);
        }
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
        this.Mybody = GetComponentInParent<Rigidbody>();
        if(Mybody == null) Debug.LogWarning("Can't Found Rigidbody");
    }
    protected void LoadPlayerCtrl()
    {
        if(playerController != null) return;
        playerController = GetComponentInParent<PlayerController>();
        if(playerController == null ) Debug.LogWarning(this.transform + "can find playerCtrl");
    }
    protected void FixedUpdate()
    {
        this.Moving();
        this.BoostSpeed(BoostValue,BoostTime);
    }
    protected void BoostSpeed(float Value,float time)
    {
        if(BuffManager.Instance.CurrentBuff == null) return;
        if(BuffManager.Instance.CurrentBuff.name == "SpeedUp")
        {
            this.Timer += Time.deltaTime * 1f;
            if(Timer <= time) ExtraSpeed = Value/100f; 
            else
            {
                this.Timer  = 0 ;
                BuffManager.Instance.CurrentBuff.name = null;
            }
        }
        else ExtraSpeed = 0;
    }
}
