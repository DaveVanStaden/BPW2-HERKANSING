using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject Enemy;
    public GameObject Player;
    public GameObject PlayerTracker;

    [Header("Variables")]
    private EnemyStats stats;
    public PlayerStats playerStats;
    private PlayerTracker tracker;
    private int damage;
    private float timer;
    void Start()
    {
        stats = Enemy.GetComponent<EnemyStats>();
        damage = stats.damage.GetValue();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2f)
            Destroy(gameObject);
        PlayerTracker = GameObject.FindGameObjectWithTag("Tracker");
        tracker = PlayerTracker.GetComponent<PlayerTracker>();
        Player = tracker.Player;
        playerStats = Player.GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerStats.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
