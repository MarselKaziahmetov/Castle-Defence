using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState: State 
{
/*    private PlayerController player;
    public DeathState(PlayerController playerController)
    {
        player = playerController;
    }*/

    public override void Enter()
    {
        base.Enter();
        Debug.Log("ўас умру");
    }

/*    public override void Update()
    {
        base.Update();
        Debug.Log("”мираю");
    }*/

    public override void Exit()
    {
        base.Exit();
        Debug.Log("«дох");
    }
}
