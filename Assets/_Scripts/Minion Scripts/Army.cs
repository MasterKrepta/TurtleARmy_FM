using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour
{

    [SerializeField] GameObject[] Turtles;
    [SerializeField]Transform spawner = null;
    public Action<int> Spawn;
    public Collider[] colliders;
    public float radius;
    

    private void Awake() {
        //spawner = FindObjectOfType<Spawn>().transform;
    }


    public void SpawnMinion(int index) {
        

        Vector3 modPos = spawner.position;
        bool canSpawnHere = false;
        int Saftey = 0;


        while (canSpawnHere == false)
        {
            float randomDistance = UnityEngine.Random.Range(-9, 9);
            modPos = new Vector3(spawner.position.x + randomDistance, 0, 0);
            canSpawnHere = PreventOverlap(modPos);
            Saftey++;

            if (canSpawnHere || Saftey > 50)
            {
                break;
            }
        }
        Instantiate(Turtles[index - 1], modPos, Quaternion.identity);

    }

    private bool PreventOverlap(Vector3 spawnPos)
    {
        colliders = Physics.OverlapSphere(spawner.position, radius);
        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 center = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.y;
            float height = colliders[i].bounds.extents.x;

            float leftExtent = center.x - width;
            float rightExtent = center.x + width;
            float lowerExtent = center.y - height;
            float upperExtent = center.y  + width;

            if (spawnPos.x >= leftExtent && spawnPos.x <= rightExtent)
            {
                if (spawnPos.y >= lowerExtent && spawnPos.y <= upperExtent) 
                {
                    return false;
                }
            }
       }
        return true;
    }
}
