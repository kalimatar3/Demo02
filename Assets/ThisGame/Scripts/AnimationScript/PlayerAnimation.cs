using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MyBehaviour
{
    [SerializeField] protected PlayerController playerController;
    [SerializeField] protected Animator PlayerAnimator;
    [SerializeField] protected bool IsDeadAnim,facing;
    protected float MoveAnim;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }
    protected void LoadPlayerCtrl()
    {
        if(playerController != null) return;
        playerController = GetComponentInParent<PlayerController>();
    }
    protected void Update()
    {
        this.Moving();
        this.Attack();
        this.IsDead();
    }
    protected void IsDead()
    {
        if(playerController.PlayerReciver.CurrentHp <= 0)
        {
            IsDeadAnim = true;
        }
        else
        {
            IsDeadAnim = false;
        }
        PlayerAnimator.SetBool(StringConts.PlayerIsDead,IsDeadAnim);
    }
    protected void Moving()
    {
        if(InputManager.Instance.MovingJoystick.Horizontal * InputManager.Instance.Shootingstick.Horizontal < 0 || InputManager.Instance.MovingJoystick.Vertical * InputManager.Instance.Shootingstick.Vertical < 0 )
        {
            facing = false;
        }
        else facing = true;
        this.MoveAnim = playerController.PlayerMoving.Move.magnitude;
        PlayerAnimator.SetFloat(StringConts.PlayerMoveAnim,MoveAnim);
        PlayerAnimator.SetBool(StringConts.PlayerFacingAnim,facing);       
    }
    protected void Attack()
    {
        Vector3 GunDirection = new Vector3 (InputManager.Instance.Shootingstick.Horizontal,0 ,InputManager.Instance.Shootingstick.Vertical);
        PlayerAnimator.SetFloat(StringConts.PlayerFireAnim,GunDirection.magnitude);
    }
}
