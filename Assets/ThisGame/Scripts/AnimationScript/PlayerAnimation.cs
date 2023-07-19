using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MyBehaviour
{
    [SerializeField] protected PlayerController playerController;
    [SerializeField] protected Animator PlayerAnimator;
    protected float MoveAnim;
    protected bool IsDeadAnim;
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
        if(playerController.PlayerReciver.CurrentHp <= 0)
        {
            IsDeadAnim = true;
        }
        this.MoveAnim = playerController.PlayerMoving.Move.magnitude;
        Vector3 GunDirection = new Vector3 (InputManager.Instance.Shootingstick.Horizontal,0 ,InputManager.Instance.Shootingstick.Vertical);
        PlayerAnimator.SetFloat(StringConts.PlayerFireAnim,GunDirection.magnitude);
        PlayerAnimator.SetBool(StringConts.PlayerIsDead,IsDeadAnim);
        PlayerAnimator.SetFloat(StringConts.PlayerMoveAnim,MoveAnim);
    }
}
