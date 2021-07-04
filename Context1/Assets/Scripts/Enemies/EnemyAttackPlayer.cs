using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackPlayer : BaseState
{
    public NavMeshAgent NavEnemy;
    public GameObject Player;
    public GameObject Projectile;
    public GameObject PlayerSearcher;
    private PlayerTracker tracker;
    public LayerMask whatIsPlayer;

    private Projectile projectile;
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public override void OnEnter()
    {
        PlayerSearcher = GameObject.FindGameObjectWithTag("Tracker");
        tracker = PlayerSearcher.GetComponent<PlayerTracker>();
        alreadyAttacked = false;
    }
    public override void OnExit()
    {
        alreadyAttacked = true;
    }
    public override void OnUpdate()
    {
        Player = tracker.Player;
        CheckState();
    }
    private void AttackPlayer()
    {
        NavEnemy.SetDestination(transform.position);

        transform.LookAt(Player.transform);

        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(Projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 12f, ForceMode.Impulse);
            rb.AddForce(transform.up * 2f, ForceMode.Impulse);

            projectile = rb.GetComponent<Projectile>();
            projectile.Enemy = this.gameObject;


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    private void CheckState()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInSightRange && !playerInAttackRange) owner.SwitchState(typeof(EnemyPatrol));
        if (playerInSightRange && !playerInAttackRange) owner.SwitchState(typeof(EnemyChasePlayer));
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }
}
