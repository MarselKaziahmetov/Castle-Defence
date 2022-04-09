using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStateMob: State
{
    private MobControll _mob;

    public IdleStateMob(MobControll mobControll)
    {
        _mob = mobControll;
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
