using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Главный скрипт,который висит на объекте Player(персонаже игрока)*/

public class PlayerController : MonoBehaviour
{
    public StateMachine stateMachine;

    public IdleState idleState;
    public RunState runState;
    public DeathState deathState;

    public Animator animator;
    public Rigidbody rb;

    public float rotationSpeed = 10;
    public float movementSpeed = 4;
    [HideInInspector] public float hAxes;
    [HideInInspector] public float vAxes;

    void Start()
    {
        idleState = new IdleState(this);
        runState = new RunState(this);
        deathState = new DeathState();

        stateMachine = new StateMachine();
        stateMachine.Initialize(idleState);

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        stateMachine.CurrentState.Update();

        hAxes = Input.GetAxis("Horizontal");
        vAxes = Input.GetAxis("Vertical");

        if ((hAxes != 0 || vAxes != 0) && (stateMachine.CurrentState != runState))
        {
            stateMachine.ChangeState(runState);
        }
        
        if ((hAxes == 0 && vAxes == 0) && (stateMachine.CurrentState != idleState))
        {
                stateMachine.ChangeState(idleState);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            stateMachine.ChangeState(deathState);
        }
    }
}
