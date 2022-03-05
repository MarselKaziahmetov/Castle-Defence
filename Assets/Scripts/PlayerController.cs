using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*Главный скрипт,который висит на объекте Player(персонаже игрока)*/

public class PlayerController : MonoBehaviour
{
    private StateMachine stateMachine;

    private IdleState idleState;
    private RunState runState;
    private DeathState deathState;

    [Header("Variables")]
    public float rotationSpeed = 10;
    public float movementSpeed = 4;

    [HideInInspector] public Animator animator;
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public Transform targetToMove;

    [HideInInspector] public float hAxes;
    [HideInInspector] public float vAxes;
    [HideInInspector] public bool isRunning = false;

    void Start()
    {
        idleState = new IdleState(this);
        runState = new RunState(this);
        deathState = new DeathState();

        stateMachine = new StateMachine();
        stateMachine.Initialize(idleState);

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        stateMachine.CurrentState.Update();

        hAxes = Input.GetAxis("Horizontal");
        vAxes = Input.GetAxis("Vertical");

        if (Input.GetMouseButton(1) && (stateMachine.CurrentState != runState))
        {
            stateMachine.ChangeState(runState);
        }

        if (!Input.GetMouseButton(1) && !isRunning && (stateMachine.CurrentState != idleState))
        {
            stateMachine.ChangeState(idleState);
        }

        /*if ((hAxes != 0 || vAxes != 0) && (stateMachine.CurrentState != runState))
        {
            stateMachine.ChangeState(runState);
        }*/

        /*if ((hAxes == 0 && vAxes == 0) && (stateMachine.CurrentState != idleState))
        {
            stateMachine.ChangeState(idleState);
        }*/


        if (Input.GetKeyDown(KeyCode.U))
        {
            stateMachine.ChangeState(deathState);
        }
    }
}
