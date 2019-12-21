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

    #region Starting Values
    public float Starting_MoveSpeed = 30f;
    public float Starting_CostToSpawn = 1f;
    public float Starting_AttackPower = 1f;
    public float Starting_AttackDelay = 1f;
    public float Starting_Health = 10f;
    #endregion

    //TODO Remove the number system from the naming for release
    [SerializeField] private int _upgradeSpeed;

    
    public int UpgradeSpeed
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

    [SerializeField] private int _upgradeAttackPower;

    
    public int UpgradeAttackPower
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

    [SerializeField] private int _upgradeAttackDelay;

    
    public int UpgradeAttackDelay
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

    [SerializeField] private int _upgradeHealth;

    public int UpgradeHealth
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
