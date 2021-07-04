using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public GameObject playerTracker;
    public PlayerTracker tracker;
    public Transform Player;
    private void Awake()
    {
        playerTracker = GameObject.FindGameObjectWithTag("Tracker");
        tracker = playerTracker.GetComponent<PlayerTracker>();
    }

    private void Update()
    {
        Player = tracker.Player.transform;
    }
    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 newPosition = Player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
