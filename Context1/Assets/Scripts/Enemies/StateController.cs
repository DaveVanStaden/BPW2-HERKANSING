using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField]private EnemyStateMachine controller;

    public GameObject Player;
    public GameObject PlayerSearcher;
    private PlayerTracker tracker;
    public LayerMask whatIsPlayer;
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
