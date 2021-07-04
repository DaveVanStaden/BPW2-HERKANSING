using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public AudioSource grunt;
    public GameObject AmmoBox;
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        grunt.Play();
    }
    public override void Die()
    {
        var randNumber = Random.Range(0, 4);
        if (randNumber >= 3)
            Instantiate(AmmoBox, this.transform.position, Quaternion.identity);
        base.Die();
        Destroy(gameObject);
    }
}
