using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : CharacterStats
{
    public AudioSource grunt;
    public Text HealthText;
    public GameObject EventManager;
    private ChangeMenu changeMenu;

    private void Awake()
    {
        Time.timeScale = 1f;
        SetHealth();
        HealthText = GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text>();
        EventManager = GameObject.FindGameObjectWithTag("EventManager");
        changeMenu = EventManager.GetComponent<ChangeMenu>();
    }
    private void Update()
    {
        HealthText.text = "Health:" + currenthealth;
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        grunt.Play();
    }
    public override void Die()
    {
        base.Die();
        changeMenu.SetDeathActive();
    }
}
