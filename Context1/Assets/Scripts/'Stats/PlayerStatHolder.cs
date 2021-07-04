using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatHolder : CharacterStats
{
    //private GameObject PlayerSearcher;
    //private PlayerTracker tracker;
    //private PlayerStats stats;
    private void Awake()
    {
        SetHealth();
    }
    private void Update()
    {
        //PlayerSearcher = GameObject.FindGameObjectWithTag("Tracker");
        //tracker = PlayerSearcher.GetComponent<PlayerTracker>();
        //stats = tracker.Player.GetComponent<PlayerStats>();
    }
}
