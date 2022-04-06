using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStateMob: State
{
    private MobController _mob;

    public IdleStateMob(MobController mobController)
    {
        _mob = mobController;
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("����� � ����");

        IdleAnimation();
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("����� �� ����");
    }

    void IdleAnimation()
    {
        _mob.animator.StopPlayback();
        _mob.animator.CrossFade("idle", 0.5f);
    }
}
