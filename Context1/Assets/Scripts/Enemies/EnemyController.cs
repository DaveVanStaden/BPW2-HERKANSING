using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public enum StateEnum { Attack, Chase, Patrol }
    private StateEnum state;
    [Header("Prefabs")]
    public NavMeshAgent NavEnemy;
    public GameObject Player;
    public LayerMask whatIsGround, whatIsPlayer;
    public GameObject Projectile;
    public GameObject PlayerSearcher;
    public EnemyAnimation enemyAnim;

    [Header("Variables")]
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    private Projectile projectile;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private PlayerTracker tracker;

    private IEnumerator coroutine;

    private void Awake()
    {
        PlayerSearcher = GameObject.FindGameObjectWithTag("Tracker");
        tracker = PlayerSearcher.GetComponent<PlayerTracker>();
        enemyAnim = GetComponent<EnemyAnimation>();
    }
    void Start()
    {
        NavEnemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        Player = tracker.Player;
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInSightRange && !playerInAttackRange) state = StateEnum.Patrol;
        if (playerInSightRange && !playerInAttackRange) state = StateEnum.Chase;
        if (playerInSightRange && playerInAttackRange) state = StateEnum.Attack;
        CheckState();
    }
    void FaceTarget()
    {
        Vector3 direction = (Player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            NavEnemy.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        enemyAnim.WalkAnimation();

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
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
    private void ChasePlayer()
    {
        NavEnemy.SetDestination(Player.transform.position);
        enemyAnim.WalkAnimation();
    }
    private void AttackPlayer()
    {
        NavEnemy.SetDestination(transform.position);

        transform.LookAt(Player.transform);
        enemyAnim.AttackAnimation();
        coroutine = waitForAttack(1.7f);
        StartCoroutine(coroutine);
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    private void CheckState()
    {
        switch (state)
        {
            case StateEnum.Attack:
                AttackPlayer();
                break;
            case StateEnum.Chase:
                ChasePlayer();
                break;
            case StateEnum.Patrol:
                Patroling();
                break;
        }
    }

    private IEnumerator waitForAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(Projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 12f, ForceMode.Impulse);
            rb.AddForce(transform.up * 1f, ForceMode.Impulse);

            projectile = rb.GetComponent<Projectile>();
            projectile.Enemy = this.gameObject;


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }
}
