using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "ScriptableObjects/Abilities", order = 3)]
public class Ability : ScriptableObject
{
    public enum AbilityTypes
    { 
        Attack,
        Air,
        Edge
    }


    public AbilityTypes Type = AbilityTypes.Attack;
    public bool CanUse;
    public string Name = "New Ability";
    public float Cost = 1f;
    public float PowerAmount = 1f;
    public float CooldownTime = 1f;
    public Transform AbilitySpawnPoint;
    public Transform AbilityPrefab;
    

    public void UseAbility()
    {
        AbilitySpawnPoint = GameObject.Find($"{Type.ToString()}SpawnPoint").transform; //TODO how inefficient is this
        Instantiate(AbilityPrefab, AbilitySpawnPoint.position, Quaternion.identity);
        Debug.Log($"{Name} has been fired");
    }
}
