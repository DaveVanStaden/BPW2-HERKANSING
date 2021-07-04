using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChasePlayer : BaseState
{
    public NavMeshAgent NavEnemy;
    public GameObject Player;
    public GameObject PlayerSearcher;
    private PlayerTracker tracker;
    public LayerMask whatIsPlayer;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public override void OnEnter()
    {
        PlayerSearcher = GameObject.FindGameObjectWithTag("Tracker");
        tracker = PlayerSearcher.GetComponent<PlayerTracker>();
    }
    public override void OnExit()
    {
    }
    public override void OnUpdate()
    {
        Player = tracker.Player;
        CheckState();
    }
    private void CheckState()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInSightRange && !playerInAttackRange) owner.SwitchState(typeof(EnemyPatrol));
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) owner.SwitchState(typeof(EnemyAttackPlayer));
    }
    private void ChasePlayer()
    {
        NavEnemy.SetDestination(Player.transform.position);
    }
}
