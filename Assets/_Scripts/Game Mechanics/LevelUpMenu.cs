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
        currentMinion = Upgradables[ Random.Range(0, Upgradables.Count)];
        minionName = currentMinion.name;
        AssignRandomStat();

    }
    void AssignRandomStat()
    {
        currentStat = (StatToUpgrade)UnityEngine.Random.Range(0, sizeof(StatToUpgrade));
        statName = currentStat.ToString();
        switch (currentStat)
        {
            //todo figure out level display to screen
            case StatToUpgrade.MoveSpeed:
                message = $"{minionName} gains an Increase in {statName}\n\n 0/0";
                break;
            case StatToUpgrade.AttackPower:
                message = $"{minionName} now has more {statName}\n\n 0/0";
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
        message = button.GetComponentInChildren <Text>().text;
        //1: Pause gameplay
        Time.timeScale = 0;
        currentMinion.UpdateStat(statName);
        //apply the actual stat
        //switch (currentStat)
        //{
        //    //todo do this with Json Data
        //    case StatToUpgrade.MoveSpeed:
        //        currentMinion.UpdateStat(statName);
        //        break;
        //    case StatToUpgrade.AttackPower:
        //        currentMinion.AttackPower++;
        //        break;
        //    case StatToUpgrade.AttackDelay:
        //        currentMinion.AttackDelay++;
        //        break;
        //    case StatToUpgrade.Health:
        //        currentMinion.AttackDelay++;
        //        break;
        //    default:
        //        break;
        //}

        Debug.Log(message);
        DeActivateLevelUpMenu();
        Time.timeScale = 1;
    }

    public void ActivateLevelUpMenu()
    {
        this.gameObject.SetActive(true);
        Utilities.OnGamePause();
        BeginMenu();
    }

    public void DeActivateLevelUpMenu()
    {
        this.gameObject.SetActive(false);
        Utilities.OnGamePause();
    }
}