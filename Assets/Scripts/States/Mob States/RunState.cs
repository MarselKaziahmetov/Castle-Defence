using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunStateMob: State
{
    private MobControll _mob;

    public RunStateMob(MobControll mobControll)
    {
        _mob = mobControll;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("�������");

        RunningAnimation();
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("����");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("�������");
    }

    void RunningAnimation()
    {
        _mob.animator.StopPlayback();
        _mob.animator.CrossFade("running", 0.1f);
    }
}
