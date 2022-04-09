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
        Debug.Log("Побежал");

        RunningAnimation();
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("Бегу");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Добежал");
    }

    void RunningAnimation()
    {
        _mob.animator.StopPlayback();
        _mob.animator.CrossFade("running", 0.1f);
    }
}
