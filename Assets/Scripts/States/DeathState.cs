using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState: State 
{
    private PlayerController _player;
    public DeathState(PlayerController playerController)
    {
        _player = playerController;
    }

    public override void Enter()
    {
        base.Enter();
        DeathAnimation();
        Debug.Log("Щас умру");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Здох");
    }

    void DeathAnimation()
    {
        _player.animator.StopPlayback();
        _player.animator.CrossFade("death", 0.1f);
    }
}
