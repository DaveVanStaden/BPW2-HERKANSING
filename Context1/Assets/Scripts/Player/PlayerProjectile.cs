using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerProjectile : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject Enemy;

    [Header("Variables")]
    private EnemyStats stats;
    private int damage;
    private float timer;
    private CharacterStats playerStats;
    private void Awake()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
    }
    private void Update()
    {
        damage = playerStats.damage.baseValue;
        timer += Time.deltaTime;
        if (timer >= 2f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyStats target = collision.transform.GetComponent<EnemyStats>();
            var tempEnemy = collision.gameObject;
            target = tempEnemy.GetComponent<EnemyStats>();
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
