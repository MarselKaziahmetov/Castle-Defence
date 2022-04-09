using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStateMob: State 
{
    private MobControll _mob;

    public DeathStateMob(MobControll mobControll)
    {
        _mob = mobControll;
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
        _mob.animator.StopPlayback();
        _mob.animator.CrossFade("death", 0.1f);
    }
}
