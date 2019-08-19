using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour
{

    [SerializeField] GameObject[] Turtles;
    [SerializeField]Transform spawner;
    public Action<int> Spawn;

    private void Awake() {
        //spawner = FindObjectOfType<Spawn>().transform;
    }


    public void SpawnMinion(int index) {
        float randomDistance = UnityEngine.Random.Range(-5, 5);
        
        Vector3 modPos = new Vector3(spawner.position.x + randomDistance, 0, 0);


        Instantiate(Turtles[index - 1], modPos, Quaternion.identity);
    }
}
