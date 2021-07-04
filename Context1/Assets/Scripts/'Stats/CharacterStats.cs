using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public int Health = 100;
    public int currenthealth { get; set; }

    public Stat damage;
    public Stat armor;

    public Text damageText;
    private void Awake()
    {
        SetHealth();
    }
    private void Update()
    {
    }
    public virtual void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currenthealth -= damage;
        if(currenthealth <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        //meant to be overwritten so each character can die in their own ways.
    }
    public void SetHealth()
    {
        currenthealth = Health;
    }

}
