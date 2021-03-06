using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState: State
{
    private PlayerController _player;

    public IdleState(PlayerController playerController)
    {
        _player = playerController;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("????? ? ????");

        IdleAnimation();
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("????? ?? ????");
    }

    void IdleAnimation()
    {
        _player.animator.StopPlayback();
        _player.animator.CrossFade("idle", 0.5f);
    }
}
