using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Minions", order = 1)]

public class Minion : ScriptableObject
{
    [SerializeField] int maxLevel = 2;
    public float MoveSpeed = 30f;
    public float CostToSpawn = 1f;
    public float AttackPower = 1f;
    public float AttackDelay = 1.25f; //todo might need to rething this
    public float Health = 10f;
    public int MaxUpgrades = 20;
    public int CurrentUpgrades = 0;
    public string Name = "";
    public string Desc = "Desc Not Set";
    public float CostToUpgrade = 100;
    public float CostIncreasePerUpgrade = 1.2f;
    public float MinAttackDelay = 0.25f;
    

    #region Starting Values
    public float Starting_MoveSpeed = 30f;
    public float Starting_CostToSpawn = 1f;
    public float Starting_AttackPower = 1f;
    public float Starting_AttackDelay = 1f;
    public float Starting_Health = 10f;
    #endregion

    //TODO Remove the number system from the naming for release
    [SerializeField] private float _upgradeSpeed;

    
    public float UpgradeSpeed
    {
        get { return _upgradeSpeed; }
        set { 
            _upgradeSpeed = value;
            if (_upgradeSpeed >= maxLevel)
            {
                //Debug.Log($"Time to remove {this.name} card for speed");
                RemoveCard();
            }
        }
    }

    [SerializeField] private float _upgradeAttackPower;

    
    public float UpgradeAttackPower
    {
        get { return _upgradeAttackPower; }
        set 
        {
            _upgradeAttackPower = value;
            if (UpgradeAttackPower >= maxLevel)
            {
                //Debug.Log($"Time to remove {this.name} card for power");
                RemoveCard();
            }
        }
    }

    [SerializeField] private float _upgradeAttackDelay;

    
    public float UpgradeAttackDelay
    {
        get { return _upgradeAttackDelay; }
        set
        { 

            _upgradeAttackDelay = value;
            
            if (UpgradeAttackDelay >= maxLevel)
            {
               // Debug.Log($"Time to remove {this.name} card for delay");
                RemoveCard();
            }
        }
    }

    [SerializeField] private float _upgradeHealth;

    public float UpgradeHealth
    {
        get { return _upgradeHealth; }
        set 
        { 
            _upgradeHealth = value;
            if (UpgradeHealth >= maxLevel)
            {
               // Debug.Log($"Time to remove {this.name} card for health");
                RemoveCard();
            }
        }
    }

    void RemoveCard()
    {
        LevelUpMenu.Instance.RemoveCard(Helpers.CurrentCard);
    }
}
