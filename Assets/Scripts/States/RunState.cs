using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState: State
{
    private PlayerController _player;

    public RunState(PlayerController playerController)
    {
        _player = playerController;
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

        NewRunLogic();
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Добежал");
    }

    void NewRunLogic()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit))
        {
            _player.targetToMove = hit.transform;
            _player.navMeshAgent.isStopped = false;
            _player.isRunning = true;
            _player.navMeshAgent.destination = hit.point;

            if (!Input.GetMouseButton(1))
            {
                _player.isRunning = false;
                _player.navMeshAgent.isStopped = true;
            }
        }
    }

    void RunningAnimation()
    {
        _player.animator.StopPlayback();
        _player.animator.CrossFade("running", 0.1f);
    }
}
