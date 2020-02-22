using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSavePlayerData : MonoBehaviour
{
    [SerializeField] Minion playerData;
    [SerializeField] Minion[] MinionData;
    private void OnEnable()
    {

        //TODO DANGER!!! TESTING ONLY!!!!
        //todo *******************************************************************
        //PlayerPrefs.DeleteAll();
        //todo *******************************************************************

        DontDestroyOnLoad(this);
        foreach (var m in MinionData)
        {
            
            if (m.CurrentUpgrades == 0)
            {
                m.Health = m.Starting_Health;
                m.AttackPower = m.Starting_AttackPower;
                m.MoveSpeed = m.Starting_MoveSpeed;
                m.AttackDelay = m.Starting_AttackDelay;
            } //For Reset
            LoadStats(m);
            //print($"Health of {m.Name} is : {PlayerPrefs.GetFloat(m.Name + "_Health")}");
        }
    }

  
    public static void SaveStats(Minion m)
    {
        PlayerPrefs.SetInt($"{m.Name}_CurrentUpgrades", m.CurrentUpgrades);
        PlayerPrefs.SetFloat($"{m.Name}_Health", m.Health);
        PlayerPrefs.SetFloat($"{m.Name}_AttackPower", m.AttackPower);
        PlayerPrefs.SetFloat($"{m.Name}_MoveSpeed", m.MoveSpeed);
        PlayerPrefs.SetFloat($"{m.Name}_AttackDelay", m.AttackDelay);
        PlayerPrefs.Save();

    }

    public static void LoadStats(Minion m)
    {
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

    private void OnApplicationQuit()
    {
        foreach (var item in MinionData)
        {
            SaveStats(item);
            PlayerPrefs.Save(); // alledgedly we dont need this. 
        }
    }
}
