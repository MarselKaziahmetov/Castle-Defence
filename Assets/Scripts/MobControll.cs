using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MobControll : MonoBehaviour
{
    private HealthSystem health;

    [HideInInspector] public Animator animator;
    [HideInInspector] public Rigidbody rb;

    [Range(0, 360)] public float viewAngle = 90f;
    public float viewDistance = 15f;
    public float detectionDistance = 3f;
    public Transform enemyEye;
    public Transform target;

    private NavMeshAgent agent;
    private Transform agentTransform;

    private bool isDead = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        health = GetComponent<HealthSystem>();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agentTransform = agent.transform;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(target.transform.position, agent.transform.position);
        
        if (distanceToPlayer <= detectionDistance || IsInView())
        {
            RotateToTarget();
            MoveToTarget();
        }
        DrawViewState();

        if ((health.currentHealth <= 0) && isDead == false)
        {
            target = null;
            Destroyer(5f);
            isDead = true;
        }
    }

    private bool IsInView() // true если цель видна
    {
        float realAngle = Vector3.Angle(enemyEye.forward, target.position - enemyEye.position);
        RaycastHit hit;
        
        if (Physics.Raycast(enemyEye.transform.position, target.position - enemyEye.position, out hit, viewDistance))
        {
            if (realAngle < viewAngle / 2f && Vector3.Distance(enemyEye.position, target.position) <= viewDistance && hit.transform == target.transform)
            {
                return true;
            }
        }
        
        return false;
    }

    private void RotateToTarget() // поворачивает в сторону цели со скоростью rotationSpeed
    {
        Vector3 lookVector = target.position - agentTransform.position;
        lookVector.y = 0;
        if (lookVector == Vector3.zero) return;
        agentTransform.rotation = Quaternion.RotateTowards
            (
                agentTransform.rotation,
                Quaternion.LookRotation(lookVector, Vector3.up),
                agent.angularSpeed * Time.deltaTime
            );
    }

    private void MoveToTarget() // устанвливает точку движения к цели
    {
        agent.SetDestination(target.position);
    }

    private void DrawViewState()
    {
        Vector3 left = enemyEye.position + Quaternion.Euler(new Vector3(0, viewAngle / 2f, 0)) * (enemyEye.forward * viewDistance);
        Vector3 right = enemyEye.position + Quaternion.Euler(-new Vector3(0, viewAngle / 2f, 0)) * (enemyEye.forward * viewDistance);
        Debug.DrawLine(enemyEye.position, left, Color.yellow);
        Debug.DrawLine(enemyEye.position, right, Color.yellow);
    }

    public void Destroyer(float delay)
    {
        Destroy(gameObject, delay);
        ChangeAnimation("death");

    }

    void ChangeAnimation(string animationName)
    {
        animator.StopPlayback();
        animator.CrossFade(animationName, 0.1f);
    }
}
