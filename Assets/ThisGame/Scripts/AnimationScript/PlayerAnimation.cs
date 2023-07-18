using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MyBehaviour
{
    [SerializeField] protected PlayerController playerController;
    protected float MoveAnim;
    [SerializeField] protected Animator PlayerAnimator;
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
        this.MoveAnim = playerController.PlayerMoving.Move.magnitude;
        Vector3 GunDirection = new Vector3 (InputManager.Instance.Shootingstick.Horizontal,0 ,InputManager.Instance.Shootingstick.Vertical);
        PlayerAnimator.SetFloat(StringConts.PlayerFireAnim,GunDirection.magnitude);
        PlayerAnimator.SetFloat(StringConts.PlayerMoveAnim,MoveAnim);
    }
}
