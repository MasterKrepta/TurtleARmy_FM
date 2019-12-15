using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField]LevelData data;
    float timeToNextSpawn = 0;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Utilities.Paused) { return; }

        if (Time.time > timeToNextSpawn) {
            int rand = Random.Range(0, data.EnemyTypes.Length);
            GameObject go =  Instantiate (data.EnemyTypes[rand], transform.position, transform.rotation);

            go.transform.position += new Vector3(Random.Range(-1, 1), 0, 0);

            timeToNextSpawn = Time.time + data.SpawnRate;
        }
    }
}
