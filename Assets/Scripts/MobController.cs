using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MobController : MonoBehaviour
{
    public StateMachineMob stateMachine;

    private IdleStateMob idleState;
    private RunStateMob runState;
    private DeathStateMob deathState;

    private HealthSystem health;

    [HideInInspector] public Animator animator;
    [HideInInspector] public Rigidbody rb;

    [Header("Variables")]
    [Range(0, 360)] public float ViewAngle = 90f;
    public float rotationSpeed = 10;
    public float ViewDistance = 15f;
    public float DetectionDistance = 3f;

    public Transform EnemyEye;
    public Transform Target;
    private NavMeshAgent agent;
    private Transform agentTransform;

    void Start()
    {
        /*        idleState = new IdleStateMob(this);
        runState = new RunStateMob(this);
        deathState = new DeathStateMob(this);

        stateMachine = new StateMachineMob();
        stateMachine.Initialize(idleState);*/

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        rotationSpeed = agent.angularSpeed;
        agentTransform = agent.transform;
    }

    private void Update()
    {
        stateMachine.CurrentState.Update();

        if ((stateMachine.CurrentState != runState) && (stateMachine.CurrentState != deathState))
        {
            stateMachine.ChangeState(runState);
        }

        if ((stateMachine.CurrentState != idleState) && (stateMachine.CurrentState != deathState))
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
