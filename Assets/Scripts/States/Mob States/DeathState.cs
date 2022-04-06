using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStateMob: State 
{
    private MobController _mob;

    public DeathStateMob(MobController mobController)
    {
        _mob = mobController;
    }

    public override void Enter()
    {
        base.Enter();
        DeathAnimation();

        Debug.Log("��� ����");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("����");
    }

    void DeathAnimation()
    {
        _mob.animator.StopPlayback();
        _mob.animator.CrossFade("death", 0.1f);
    }
}
