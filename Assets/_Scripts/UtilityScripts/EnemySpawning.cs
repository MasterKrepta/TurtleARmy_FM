using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField]LevelData data;
    float timeToNextSpawn = 0;
    public Collider[] colliders;
    public float radius;

    // Update is called once per frame
    void Update()
    {
        if (Helpers.Paused) { return; }
        if (Helpers.GameOver) { return; }

        if (Time.time > timeToNextSpawn) {
            int rand = Random.Range(0, data.EnemyTypes.Length);
            GameObject go =  Instantiate (data.EnemyTypes[rand], transform.position, transform.rotation);

            //TODO does this actually add value to the visuals?
            Vector3 modPos = transform.position;
            bool canSpawnHere = false;
            int Safety = 0;

            while (canSpawnHere == false)
            {
                canSpawnHere = PreventOverlap(modPos);
                Safety++;

                if (canSpawnHere || Safety > 50)
                {
                    break;
                }
            }
            go.transform.position += new Vector3(Random.Range(-7, 3), 0, 0); //TODO this is enemy spawning pos

            timeToNextSpawn = Time.time + data.SpawnRate;
        }
    }

    private bool PreventOverlap(Vector3 spawnPos)
    {
        colliders = Physics.OverlapSphere(transform.position, radius);
        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 center = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.y;
            float height = colliders[i].bounds.extents.x;

            float leftExtent = center.x - width;
            float rightExtent = center.x + width;
            float lowerExtent = center.y - height;
            float upperExtent = center.y + width;

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

    public void BeginSurge()
    {
        print("Surge activated");
        StartCoroutine(Surge());
    }

    IEnumerator Surge()
    {
        foreach (var e in data.SurgeEnemyTypes)
        {
            GameObject go = Instantiate(e, transform.position, transform.rotation);
            print(go.name + " has spawned");
            yield return new WaitForSeconds(data.SurgeSpawnRate);
        }
    }
}