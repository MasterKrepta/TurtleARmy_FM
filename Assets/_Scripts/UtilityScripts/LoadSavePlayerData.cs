using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSavePlayerData : MonoBehaviour
{
    public static LoadSavePlayerData Instance;
    [SerializeField] Minion playerData;
    [SerializeField] Money PlayerMoney;
    [SerializeField] Minion[] MinionData;

    public LoadSavePlayerData()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        ConfigureMinionStats();
        SceneManagement.OnLevelOver += SavePlayerMoney;
        DontDestroyOnLoad(this);
    }
    private void OnDisable()
    {
        SceneManagement.OnLevelOver -= SavePlayerMoney;
    }

    public void SaveAll()
    {
        foreach (var m in MinionData)
        {
            SaveStats(m);
        }
        SavePlayerMoney();
    }
    public void SavePlayerMoney()
    {
        PlayerPrefs.SetFloat("CurrentMoney", PlayerMoney.CurrentMoney);
        PlayerPrefs.Save();
    }

    public void LoadPlayerMoney()
    {
        if (PlayerPrefs.HasKey("CurrentMoney"))
        {
            PlayerMoney.CurrentMoney = PlayerPrefs.GetFloat("CurrentMoney");

        }
        else
        {
            PlayerMoney.CurrentMoney = PlayerMoney.StartingMoney;
        }
    }

    private void ConfigureMinionStats()
    {
        foreach (var m in MinionData)
        {

            if (m.CurrentUpgrades == 0)
            {
                AssignDefaults(m);
            }
            LoadStats(m);
            //print($"Health of {m.Name} is : {PlayerPrefs.GetFloat(m.Name + "_Health")}");
        }
        LoadPlayerMoney();
        LoadPlayerData();
    }

    private void LoadPlayerData()
    {
        if (playerData == null)
        {
            Debug.LogWarning("TODO: PLayer data saving and loading");
        }
        
    }

    private static void AssignDefaults(Minion m)
    {
        m.CurrentUpgrades = 0;
        m.CostToUpgrade = m.Starting_Cost;
        m.Health = m.Starting_Health;
        m.AttackPower = m.Starting_AttackPower;
        m.MoveSpeed = m.Starting_MoveSpeed;
        m.AttackDelay = m.Starting_AttackDelay;
    }

    public static void SaveStats(Minion m)
    {
        PlayerPrefs.SetFloat($"{m.Name}_CostToUpgrade", m.CostToUpgrade);
        PlayerPrefs.SetInt($"{m.Name}_CurrentUpgrades", m.CurrentUpgrades);
        PlayerPrefs.SetFloat($"{m.Name}_Health", m.Health);
        PlayerPrefs.SetFloat($"{m.Name}_AttackPower", m.AttackPower);
        PlayerPrefs.SetFloat($"{m.Name}_MoveSpeed", m.MoveSpeed);
        PlayerPrefs.SetFloat($"{m.Name}_AttackDelay", m.AttackDelay);
        PlayerPrefs.Save();

    }

    public static void LoadStats(Minion m)
    {
        if (PlayerPrefs.HasKey($"{m.Name}_CostToUpgrade"))
        {
            m.CostToUpgrade = PlayerPrefs.GetFloat($"{m.Name}_CostToUpgrade");
        }
        if (PlayerPrefs.HasKey($"{ m.Name}_Health"))
        {
            m.Health = PlayerPrefs.GetFloat($"{m.Name}_Health");
        
        }
        if (PlayerPrefs.HasKey($"{m.Name}_CurrentUpgrades")){
            m.CurrentUpgrades = PlayerPrefs.GetInt($"{m.Name}_CurrentUpgrades");
        }

        if (PlayerPrefs.HasKey($"{m.Name}_AttackPower")){
            m.AttackPower = PlayerPrefs.GetFloat($"{m.Name}_AttackPower");
        }
        if (PlayerPrefs.HasKey($"{m.Name}_MoveSpeed")){
            m.MoveSpeed = PlayerPrefs.GetFloat($"{m.Name}_MoveSpeed");
        }

        if (PlayerPrefs.HasKey($"{m.Name}_AttackDelay")){
            m.AttackDelay = PlayerPrefs.GetFloat($"{m.Name}_AttackDelay");
        }
    }


    public void DELETE_PREFS()
    {
        //? DANGER!!! TESTING ONLY!!!!
        //*******************************************************************
        PlayerPrefs.DeleteAll();
        foreach (var m in MinionData)
        {
            m.CurrentUpgrades = 0;
        }
        ConfigureMinionStats();
        Debug.LogWarning("ALL PREFS DELETED");
        //*******************************************************************
    }

    public void GiveCreditsForTesting()
    {
        PlayerMoney.CurrentMoney += 1000;
    }
}
