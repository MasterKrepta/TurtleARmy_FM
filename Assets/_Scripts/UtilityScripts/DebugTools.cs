using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTools : MonoBehaviour
{
    [SerializeField] List<Minion> AllMinions = new List<Minion>();
    [SerializeField] UpgradeCard[] Card_ScriptableObjs;

    private static DebugTools _instance;
    public static DebugTools Instance
    {
        get
        {
            return _instance;
        }
    }

    public DebugTools()
    {
        _instance = this;
    }

    void Awake()
    {
        Card_ScriptableObjs = (UpgradeCard[])Resources.FindObjectsOfTypeAll(typeof(UpgradeCard));
        ResetAllMinions(); //TODo remove this for release
        //ResetAllCards();
        //DontDestroyOnLoad(Instance);
    }

    private void OnEnable()
    {
        Helpers.OnResetCards += ResetAllCards;
    }

    private void OnDisable()
    {
        Helpers.OnResetCards -= ResetAllCards;
    }

    void ResetAllMinions()
    {
        print("Reset minions");
        foreach (var item in AllMinions)
        {
            item.MoveSpeed = item.Starting_MoveSpeed;
            item.CostToSpawn = item.Starting_CostToSpawn;
            item.AttackPower = item.Starting_AttackPower;
            item.AttackDelay = item.Starting_AttackDelay;
            item.Health = item.Starting_Health;

            item.UpgradeAttackDelay = 0;
            item.UpgradeAttackPower = 0;
            item.UpgradeHealth = 0;
            item.UpgradeSpeed = 0;
        }
    }

    public void ResetAllCards()
    {
        print("Cards Reset");
        foreach (var item in Card_ScriptableObjs)
        {
            item.IsMaxLevel = false;
            
        }
        
    }
}
