using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
}
