using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WandData", menuName = "ScriptableObjects/Wands", order = 2)]
public class WandData : ScriptableObject
{
    public enum WandType { ATTACK, HEAL, SUPPORT }
    
    public string Name = "NewWand";
    [SerializeField] WandType CurrentWand = WandType.ATTACK;
    public float Cost = 1f;
    public float PowerAmount = 1f;
    public float CooldownTime = 1f;
    public Transform WandPrefab;
    
}
