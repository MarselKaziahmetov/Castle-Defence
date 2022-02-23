#define Mobile
#undef PC

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

#if (Mobile)
        JoystickRunLogic();
#endif

#if (PC)
        PCRunLogic();
#endif

    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Добежал");
    }

    void PCRunLogic()
    {
        Vector3 directionVector = new Vector3(-_player.hAxes, 0, -_player.vAxes);

        if (directionVector.magnitude != 0)
        {
            _player.transform.rotation = Quaternion.Lerp(_player.transform.rotation, Quaternion.LookRotation(directionVector), Time.deltaTime * _player.rotationSpeed);
        }

        _player.rb.velocity = Vector3.ClampMagnitude(directionVector, 1) * _player.movementSpeed;
    }

    void JoystickRunLogic()
    {
        _player.rb.velocity = new Vector3(-_player.joystick.Horizontal * _player.movementSpeed, _player.rb.velocity.y, -_player.joystick.Vertical * _player.movementSpeed);

        if (_player.joystick.Horizontal != 0 || _player.joystick.Vertical != 0)
        {
            _player.transform.rotation = Quaternion.LookRotation(_player.rb.velocity);
        }
    }

    void RunningAnimation()
    {
        _player.animator.StopPlayback();
        _player.animator.CrossFade("running", 0.1f);
    }
}
