using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "ScriptableObjects/Abilities", order = 3)]
public class Ability : ScriptableObject
{
    public bool CanUse;
    public string Name = "New Ability";
    public float Cost = 1f;
    public float PowerAmount = 1f;
    public float CooldownTime = 1f;
    public Transform AbilitySpawnPoint;
    public Transform AbilityPrefab;
    

    public void UseAbility()
    {
        Instantiate(AbilityPrefab, AbilitySpawnPoint.position, Quaternion.identity);
        Debug.Log($"{Name} has been fired");
    }
}
