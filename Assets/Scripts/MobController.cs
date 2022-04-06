using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    public StateMachineMob stateMachine;

    private IdleStateMob idleState;
    private RunStateMob runState;
    private DeathStateMob deathState;

    private HealthSystem health;

    [Header("Variables")]
    public float rotationSpeed = 10;
    public float movementSpeed = 4;

    [HideInInspector] public Animator animator;
    [HideInInspector] public Rigidbody rb;

    [HideInInspector] public float hAxes;
    [HideInInspector] public float vAxes;
    [HideInInspector] public bool isRunning = false;

    void Start()
    {
        idleState = new IdleStateMob(this);
        runState = new RunStateMob(this);
        deathState = new DeathStateMob(this);

        stateMachine = new StateMachineMob();
        stateMachine.Initialize(idleState);

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        health = GetComponent<HealthSystem>();
    }

    private void FixedUpdate()
    {
        stateMachine.CurrentState.Update();

        hAxes = Input.GetAxis("Horizontal");
        vAxes = Input.GetAxis("Vertical");

        if ((hAxes != 0 || vAxes != 0) && (stateMachine.CurrentState != runState) && (stateMachine.CurrentState != deathState))
        {
            stateMachine.ChangeState(runState);
        }

        if ((hAxes == 0 && vAxes == 0) && (stateMachine.CurrentState != idleState) && (stateMachine.CurrentState != deathState))
        {
            stateMachine.ChangeState(idleState);
        }

        if ((health.currentHealth <= 0) && (stateMachine.CurrentState != deathState))
        {
            stateMachine.ChangeState(deathState);
            Destroyer(5f);
        }
    }

    public void Destroyer(float delay)
    {
        Destroy(gameObject, delay);
    }
}
