using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewCard", menuName = "ScriptableObjects/Card", order = 1)]
public class UpgradeCard : ScriptableObject
{
    public bool IsMaxLevel = false; //todo  This is to prevent the cards from loading on level load
    [SerializeField] int maxLevel = 1;
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
        Debug.Log("Assign Random Stat");
        Text = "";
        Stat = (StatToUpgrade)UnityEngine.Random.Range(0, sizeof(StatToUpgrade));
        minionName = minionToUpgrade.name;

        switch (Stat)
        {
            case StatToUpgrade.MoveSpeed:
                Text = $"{minionName} gains a speed boost \n {minionToUpgrade.UpgradeSpeed}/5";
                if (minionToUpgrade.UpgradeSpeed > maxLevel) 
                {
                    IsMaxLevel = true;
                    LevelUpMenu.Instance.RemoveCard(this);
                }
                break;
            case StatToUpgrade.AttackPower:
                Text = $"{minionName} gains an increase in power \n {minionToUpgrade.UpgradeAttackPower}/5";
                if (minionToUpgrade.UpgradeAttackPower > maxLevel)
                {
                    IsMaxLevel = true;
                    LevelUpMenu.Instance.RemoveCard(this);
                }
                break;
            case StatToUpgrade.AttackDelay:
                Text = $"{minionName} attacks faster \n {minionToUpgrade.UpgradeAttackDelay}/5";
                if (minionToUpgrade.UpgradeAttackDelay > maxLevel)
                {
                    IsMaxLevel = true;
                    LevelUpMenu.Instance.RemoveCard(this);
                }
                break;
            case StatToUpgrade.Health:
                Text = $"{minionName} can take more damage \n {minionToUpgrade.UpgradeHealth}/5";
                if (minionToUpgrade.UpgradeHealth > maxLevel)
                {
                   IsMaxLevel = true;
                    LevelUpMenu.Instance.RemoveCard(this);
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