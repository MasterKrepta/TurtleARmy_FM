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
        FloridaMan,
        Wand
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

    MinionToUpgrade currentMinon;
    StatToUpgrade currentStat;
    

    [SerializeField]List<GameObject> minions_SO = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //TODO figure out how i want to remove upgrades that have become maxed out from the list of possible
        //TODO , will probobly need refactored
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
        currentMinon = (MinionToUpgrade)UnityEngine.Random.Range(0, sizeof(MinionToUpgrade));
        minionName = currentMinon.ToString();
        AssignRandomStat();
        //TODO figure out the order this is done to minimize code

        //! This code is wrong, WE dont want to upgrade anything until we hit the button and make our selection
        switch (currentMinon)
        {
            //TODO determine these values a better way
            case MinionToUpgrade.MeleeTurtle:
                //minions_SO[0].GetComponent<MinionData>().Data.Movespeed++;
                break;
            case MinionToUpgrade.RangeTurtle:
                //minions_SO[1].GetComponent<MinionData>().Data.AttackPower++; //Todo This nees set to the bullet not the turtle
                break;
            case MinionToUpgrade.SleepyTom:
                //todo Sleepy toms attacks would be useless so i need to control for this to not be an option
                break;
            case MinionToUpgrade.Minion_4:
               // minions_SO[3].GetComponent<MinionData>().Data.Health++;
                break;
            case MinionToUpgrade.Minion_5:
                //minions_SO[4].GetComponent<MinionData>().Data.Health++;
                break;
            case MinionToUpgrade.Minion_6:
                //minions_SO[5].GetComponent<MinionData>().Data.Health++;
                break;
            case MinionToUpgrade.Minion_7:
                //minions_SO[6].GetComponent<MinionData>().Data.Health++;
                break;
            case MinionToUpgrade.Minion_8:
                //minions_SO[7].GetComponent<MinionData>().Data.Health++;
                break;
         
            case MinionToUpgrade.FloridaMan:
                //minions_SO[8].GetComponent<MinionData>().Data.Health++;
                break;
            case MinionToUpgrade.Wand:
                //minions_SO[8].GetComponent<Wand>().wandData.PowerAmount++;
                break;
            default:
                break;
        }
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
        //todo pause gameplay here
        //apply the actual stat
        
        Debug.Log(message);
        DeActivateLevelUpMenu();
        //todo resume gameplay here
    }

    public void ActivateLevelUpMenu()
    {
        this.gameObject.SetActive(true);
        BeginMenu();
    }

    public void DeActivateLevelUpMenu()
    {
        this.gameObject.SetActive(false);
    }


}
