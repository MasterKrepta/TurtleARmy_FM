using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Enemy", order = 1)]

public class Enemy : ScriptableObject
{
    public float Movespeed = 30f;

    public float AttackPower = 1f;
    public float AttackDelay = 1f;
    public float Health = 10f;
 

    public void ConfigureStats(GameObject data) {
        throw new System.NotImplementedException();
    }
}
