using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "ScriptableObjects/Level", order = 3)]
public class LevelData : ScriptableObject
{
    public string LevelName = "New Level";
    public GameObject[] EnemyTypes;
    public float SpawnRate = 10f;
    public int BaseHealth = 200;

    [Header("Surge Settings")]
    public float SurgeSpawnRate = 1.5f;
    public int NumToSurge = 5;
    public GameObject[] SurgeEnemyTypes;

}
