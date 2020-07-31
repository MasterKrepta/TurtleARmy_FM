using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewCard", menuName = "ScriptableObjects/Card", order = 1)]
public class UpgradeCard : ScriptableObject
{
    public bool IsMaxLevel = false; 
    [SerializeField] int maxLevel = 2;
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

    public Minion minionToUpgrade;
    

    public void ConfigureCardText()
    {
        Debug.Log("ConfigureCard");
        Text = "";
        //Stat = (StatToUpgrade)UnityEngine.Random.Range(0, sizeof(StatToUpgrade));
        minionName = minionToUpgrade.name;
        //? Look at this code closely, I may be calling remove card too frequently
        switch (Stat)
        {
            case StatToUpgrade.MoveSpeed:
                Text = $"{minionName} gains a speed boost \n {minionToUpgrade.UpgradeSpeed}/{maxLevel}";
                if (minionToUpgrade.UpgradeSpeed > maxLevel) 
                {
                    IsMaxLevel = true;
                    LevelUpMenu.Instance.RemoveCard(this);
                }
                break;
            case StatToUpgrade.AttackPower:
                Text = $"{minionName} gains an increase in power \n {minionToUpgrade.UpgradeAttackPower}/{maxLevel}";
                if (minionToUpgrade.UpgradeAttackPower > maxLevel)
                {
                    IsMaxLevel = true;
                    LevelUpMenu.Instance.RemoveCard(this);
                }
                break;
            case StatToUpgrade.AttackDelay:
                Text = $"{minionName} attacks faster \n {minionToUpgrade.UpgradeAttackDelay}/{maxLevel}";
                if (minionToUpgrade.UpgradeAttackDelay > maxLevel)
                {
                    IsMaxLevel = true;
                    LevelUpMenu.Instance.RemoveCard(this);
                }
                break;
            case StatToUpgrade.Health:
                Text = $"{minionName} can take more damage \n {minionToUpgrade.UpgradeHealth}/{maxLevel}";
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
        Helpers.CurrentCard = card; //? this is not the best option
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