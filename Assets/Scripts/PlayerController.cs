using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

/*Главный скрипт,который висит на объекте Player(персонаже игрока)*/

public class PlayerController : MonoBehaviour
{
    public StateMachinePlayer stateMachine;

    private IdleState idleState;
    private RunState runState;
    private DeathState deathState;

    private HealthSystem health;

    [Header("Variables")]
    public float rotationSpeed = 10;
    public float movementSpeed = 4;

    public Slider sliderHP;
    public ParticleSystem deathParticles;

    [HideInInspector] public Animator animator;
    [HideInInspector] public Rigidbody rb;

    [HideInInspector] public float hAxes;
    [HideInInspector] public float vAxes;
    [HideInInspector] public bool isRunning = false;
    [HideInInspector] private float currentHealthTemp;


    void Start()
    {
        idleState = new IdleState(this);
        runState = new RunState(this);
        deathState = new DeathState(this);

        stateMachine = new StateMachinePlayer();
        stateMachine.Initialize(idleState);

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        health = GetComponent<HealthSystem>();

        deathParticles.Stop();
    }

    private void Update()
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

        HPBarController();
    }

    public void Destroyer(float delay)
    {
        Destroy(gameObject, delay);
        deathParticles.Play();
    }

    public void HPBarController()
    {
        if (health.currentHealth != currentHealthTemp)
        {
            sliderHP.value = health.maxHealth / 100 * health.currentHealth;
            currentHealthTemp = health.currentHealth;
        }
    }
}
