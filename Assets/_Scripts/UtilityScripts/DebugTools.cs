using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTools : MonoBehaviour
{
    [SerializeField] List<Minion> AllMinions = new List<Minion>();
    void Awake()
    {
        ResetAllMinions();
    }

    void ResetAllMinions()
    {
        foreach (var item in AllMinions)
        {
            item.MoveSpeed = item.Starting_MoveSpeed;
            item.CostToSpawn = item.Starting_CostToSpawn;
            item.AttackPower = item.Starting_AttackPower;
            item.AttackDelay = item.Starting_AttackDelay;
            item.Health = item.Starting_Health;
            item.oldValue = "";
            
        }
    }
}
