using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewCard", menuName = "ScriptableObjects/Card", order = 1)]
public class UpgradeCard : ScriptableObject
{
    public bool MaxLevel = false;
    enum StatToUpgrade
    {
        MoveSpeed,
        //CostToSpawn,
        AttackPower,
        AttackDelay,
        Health
    }
    public Sprite Icon;
    public string minionName = "";

    [SerializeField] StatToUpgrade Stat;
    public string Text;

    [SerializeField] Minion minionToUpgrade;

    public void AssignRandomStat()
    {
        Stat = (StatToUpgrade)UnityEngine.Random.Range(0, sizeof(StatToUpgrade));
        minionName = minionToUpgrade.name;
        switch (Stat)
        {
            case StatToUpgrade.MoveSpeed:
                Text = $"{minionName} gains a speed boost \n {minionToUpgrade.UpgradeSpeed}/5";
                if (minionToUpgrade.UpgradeSpeed > 5) 
                {
                    MaxLevel = true;
                }
                break;
            case StatToUpgrade.AttackPower:
                Text = $"{minionName} gains an increase in power \n {minionToUpgrade.UpgradeAttackPower}/5";
                if (minionToUpgrade.UpgradeAttackPower > 5)
                {
                    MaxLevel = true;
                }
                break;
            case StatToUpgrade.AttackDelay:
                Text = $"{minionName} attacks faster \n {minionToUpgrade.UpgradeAttackDelay}/5";
                if (minionToUpgrade.UpgradeAttackDelay > 5)
                {
                    MaxLevel = true;
                }
                break;
            case StatToUpgrade.Health:
                Text = $"{minionName} can take more damage \n {minionToUpgrade.UpgradeHealth}/5";
                if (minionToUpgrade.UpgradeHealth > 5)
                {
                    MaxLevel = true;
                }
                break;
            default:
                break;
        }
    }

    public void ApplyUpgrade(UpgradeCard card)
    {
        Helpers.CurrentCard = card; // TODO this is not the best option
        switch (Stat)
        {
            case StatToUpgrade.MoveSpeed:
                minionToUpgrade.MoveSpeed++;
                minionToUpgrade.UpgradeSpeed++;
                break;
            case StatToUpgrade.AttackPower:
                minionToUpgrade.AttackPower++;
                minionToUpgrade.UpgradeAttackPower++;
                break;
            case StatToUpgrade.AttackDelay:
                minionToUpgrade.AttackDelay -= 0.10f;
                minionToUpgrade.UpgradeAttackDelay++;
                break;
            case StatToUpgrade.Health:
                minionToUpgrade.Health++;
                minionToUpgrade.UpgradeHealth++;
                break;
            default:
                break;
        }
    }
}