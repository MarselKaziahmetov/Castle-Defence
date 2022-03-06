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

    void RunLogic()
    {
        Vector3 directionVector = new Vector3(-_player.hAxes, 0, -_player.vAxes);

        if (directionVector.magnitude != 0)
        {
            _player.transform.rotation = Quaternion.Lerp(_player.transform.rotation, Quaternion.LookRotation(directionVector), Time.deltaTime * _player.rotationSpeed);
        }

        _player.rb.velocity = Vector3.ClampMagnitude(directionVector, 1) * _player.movementSpeed;
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
