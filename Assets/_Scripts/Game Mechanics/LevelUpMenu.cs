using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour
{

    private static LevelUpMenu _instance;
    public static LevelUpMenu Instance
    {
        get
        {
            return _instance;
        }
    }
    public LevelUpMenu()
    {
        _instance = this;
    }


    [SerializeField] Button[] Buttons = new Button[3];


    enum MinionToUpgrade
    {
        MeleeTurtle,
        RangeTurtle,
        SleepyTom,
        Minion_4,
        Minion_5,
        Minion_6,
        Minion_7,
        Minion_8,
        FloridaMan
        
    }
    enum StatToUpgrade
    {
        MoveSpeed,
        //CostToSpawn,
        AttackPower,
        AttackDelay,
        Health
    }

    string minionName = "";
    string statName = "";
    string message;

    //MinionToUpgrade currentMinon;
    StatToUpgrade currentStat;
    Minion currentMinion;

    
    
    [SerializeField] List<Minion> Upgradables = new List<Minion>();
    // Start is called before the first frame update
    void Start()
    {
        //TODO figure out how i want to remove upgrades that have become maxed out from the list of possible
        //TODO will need refactored
        this.gameObject.SetActive(false);
    }

    private void BeginMenu()
    {
        minionName = "";
        statName = "";
        message = "";
        Buttons = GetComponentsInChildren<Button>();
        
        foreach (Button item in Buttons)
        {
            AssignRandomMinion();
            item.GetComponentInChildren<Text>().text = message;
        }
    }

    void AssignRandomMinion()
    {
        currentMinion = Upgradables[UnityEngine.Random.Range(0, Upgradables.Count)];
        minionName = currentMinion.name;
        AssignRandomStat();

    }
    void AssignRandomStat()
    {
        currentStat = (StatToUpgrade)UnityEngine.Random.Range(0, sizeof(StatToUpgrade));
        statName = currentStat.ToString();
       // Debug.Log($"{statName} is being sent to the button");
        switch (currentStat)
        {
            //todo figure out level display
            //TODO Reword this for the player not the developer
            case StatToUpgrade.MoveSpeed:
                message = $"{minionName} gains increased {statName}\n\n 0/0";
                break;
            case StatToUpgrade.AttackPower:
                message = $"{minionName} now has increased {statName}\n\n 0/0";
                break;
            case StatToUpgrade.AttackDelay:
                message = $"{minionName} has a decreased {statName}\n\n 0/0";
                break;
            case StatToUpgrade.Health:
                message = $"{minionName} can now take more {statName} damage\n\n 0/0";
                break;
            default:
                break;
        }
    }

    public void MakeSelection(Button button)
    {
        message = button.GetComponentInChildren<Text>().text;
        string actualStat = GetActualStat(message); //TODO fix this hack with something better
        currentMinion = GetActualMinion(message); //todo fix this hack

        Time.timeScale = 0;

        currentMinion.UpdateStat(actualStat); 
        //Debug.Log($"{currentMinion.oldValue} is old: { currentMinion.GetUpgradedValue(actualStat)} is the new value");
        Debug.Log(message);

        DeActivateLevelUpMenu();
        Time.timeScale = 1;
    }

    private Minion GetActualMinion(string message)
    {
        //TODO oh my god fix this, this method is going to be super error prone when i change the names of the SOs
        if (message.Contains("1_MeleeTurtle"))
        {

            return Upgradables[0];
        }
        else if (message.Contains("2_RangeTurtle"))
        {
            return Upgradables[1];
        }
        else if (message.Contains("3_SleepyTom"))
        {
            return Upgradables[2];
        }
        else if (message.Contains("Turtle_4"))
        {
            return Upgradables[3];
        }
        else if (message.Contains("Turtle_5"))
        {
            return Upgradables[4];
        }
        else if (message.Contains("Turtle_6"))
        {
            return Upgradables[5];
        }
        else if (message.Contains("Turtle_7"))
        {
            return Upgradables[6];
        }
        else if (message.Contains("Turtle_8"))
        {
            return Upgradables[7];
        }
        else if (message.Contains("FloridaMan"))
        {
            return Upgradables[8];
        }
        return null;

    }

    private string GetActualStat(string message)
    {
        if (message.Contains("MoveSpeed"))
        {
            return "MoveSpeed";
        }
        else if (message.Contains("AttackPower"))
        {
            return "AttackPower";
        }
        else if (message.Contains("AttackDelay"))
        {
            return "AttackDelay";
        }
        else if (message.Contains("Health"))
        {
            return "Health";
        }
        return null;

    }

    public void ActivateLevelUpMenu()
    {
        this.gameObject.SetActive(true);
        Helpers.OnGamePause();
        BeginMenu();
    }

    public void DeActivateLevelUpMenu()
    {
        this.gameObject.SetActive(false);
        Helpers.OnGamePause();
    }
}