using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTemplate : MonoBehaviour
{
    public GameObject PlayerSearcher;
    private PlayerTracker tracker;
    private GameObject Player;
    public CharacterStats stats;
    private void Awake()
    {
        PlayerSearcher = GameObject.FindGameObjectWithTag("Tracker");
        tracker = PlayerSearcher.GetComponent<PlayerTracker>();
    }
    private void Update()
    {
        Player = tracker.Player;
        stats = Player.GetComponent<CharacterStats>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ActivatePower();
            Destroy(gameObject);
        }
    }
    public virtual void ActivatePower()
    {
        //meant to be overwritten per powerup.
    }
}
