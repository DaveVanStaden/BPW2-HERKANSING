using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorInstantiator : MonoBehaviour
{
    public GameObject GeneratorHolder;
    private void Awake()
    {
        SpawnGenerator();
    }
    public void SpawnGenerator()
    {
        Instantiate(GeneratorHolder, transform.position, Quaternion.identity);
    }
}
