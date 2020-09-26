using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AReinforcements : MonoBehaviour
{
    public GameObject[] MinionTypes;
    public float delay = 1f;

    private void Start()
    {
        StartCoroutine(SpawnDelay());
    }

    private void Spawn(GameObject m)
    {
        Instantiate(m, transform.position, Quaternion.identity);
    }
    //TODO refactor this to be based on the scriptable object
    IEnumerator SpawnDelay()
    {
        foreach (var m in MinionTypes)
        {
            Spawn(m);
            yield return new WaitForSeconds(delay);
        }
    }
}
