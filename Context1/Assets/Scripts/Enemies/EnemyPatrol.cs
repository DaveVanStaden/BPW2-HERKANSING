using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : BaseState
{
    public NavMeshAgent NavEnemy;
    public GameObject Player;
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public LayerMask whatIsGround, whatIsPlayer;
    public float timeBetweenAttacks;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public override void OnEnter()
    {
        SearchWalkPoint();
    }
    public override void OnExit()
    {
        
    }
    public override void OnUpdate()
    {
        CheckState();
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }
    private void CheckState()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) owner.SwitchState(typeof(EnemyChasePlayer));
        if (playerInSightRange && playerInAttackRange) owner.SwitchState(typeof(EnemyAttackPlayer)); ;
    }
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            NavEnemy.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
}
