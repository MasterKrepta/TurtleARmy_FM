using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Minions", order = 1)]

public class Minion : ScriptableObject
{
    public float MoveSpeed = 30f;
    public float CostToSpawn = 1f;
    public float AttackPower = 1f;
    public float AttackDelay = 1f;
    public float Health = 10f;

    #region Starting Values
    public float Starting_MoveSpeed = 30f;
    public float Starting_CostToSpawn = 1f;
    public float Starting_AttackPower = 1f;
    public float Starting_AttackDelay = 1f;
    public float Starting_Health = 10f;
    #endregion

    [HideInInspector]public string oldValue = "";
    //TOdo still need to figure out how to remove these when we max level (properties im thinking)
    public int UpgradeLevel_Speed = 0;
    public int UpgradeLevel_AttackPower = 0;
    public int UpgradeLevel_AttackDelay = 0;
    public int UpgradeLevel_Health = 0;

    public void UpdateStat(string statToUpgrade)
    {
        Debug.Log($"{statToUpgrade} is whats being upgraded");
        oldValue = GetOldValue(statToUpgrade);

        switch (statToUpgrade)
        {
            case "MoveSpeed":
                MoveSpeed++;
                UpgradeLevel_Speed++;
                break;
            case "AttackPower":
                AttackPower++;
                UpgradeLevel_AttackPower++;
                break;
            case "AttackDelay":
                //todo Limit to minimum
                AttackDelay -= 0.25f;
                UpgradeLevel_AttackDelay++;
                break;
            case "Health":
                Health++;
                UpgradeLevel_Health++;
                break;

            default:
                break;
        }
    }
    public string GetOldValue(string stat)
    {
        switch (stat)
        {
            case "MoveSpeed":
                return MoveSpeed.ToString();

            case "AttackPower":
                return AttackPower.ToString();

            case "AttackDelay":
                return AttackDelay.ToString();

            case "Health":
                return Health.ToString();


            default:
                return null;

        }
    }
    public string GetUpgradedValue(string stat)
    {
        switch (stat)
        {
            case "MoveSpeed":
                return MoveSpeed.ToString();
                
            case "AttackPower":
                return AttackPower.ToString();
                
            case "AttackDelay":
                return AttackDelay.ToString();
                
            case "Health":
                return Health.ToString();
                

            default:
                return null;
                
        }
    }
}
