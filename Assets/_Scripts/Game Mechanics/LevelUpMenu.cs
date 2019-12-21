﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public List<UpgradeCard> Cards = new List<UpgradeCard>();

    private void OnEnable()
    {
        SceneManager.sceneLoaded += ConfigureCards;
        //DontDestroyOnLoad(Instance);
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= ConfigureCards;
    }

    private void InitCards()
    {
        
        var temp = transform.GetChild(0).GetComponentsInChildren<Card>();

        if (Cards.Count == 0) //TODO test this, might not want to keep this 
        {
            //TODO call end of upgrade system
        }

        foreach (var item in temp)
        {
            item.Init(Cards[ UnityEngine.Random.Range(0, Cards.Count)]);
        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {

        this.gameObject.SetActive(false);
    }



    private void ConfigureCards(Scene scene, LoadSceneMode mode)
    {
        UpgradeCard[] allCards = (UpgradeCard[])FindObjectsOfTypeAll(typeof(UpgradeCard));
        
        foreach (var item in allCards)
        {
            
            if (!item.IsMaxLevel)
            {
                //print("Add");
                Cards.Add(item);
            }
            else
            {
                LevelUpMenu.Instance.RemoveCard(item); //todo might not need this
            }
        }

    }

    public void MakeSelection(Button button)
    {
        UpgradeCard cardSelected = button.GetComponent<Card>().cardData;
        button.GetComponent<Card>().Use(cardSelected);
        //Debug.Log( button.GetComponentInChildren<Text>().text);
        DeActivateLevelUpMenu();
    }

    

    public void ActivateLevelUpMenu()
    {
        InitCards();
        this.gameObject.SetActive(true);
        Helpers.OnGamePause();
        
       
        //TODO  This may be a mistake, the event causes a stack overflow
        //Helpers.OnLevelUp(); 

    }

    public void DeActivateLevelUpMenu()
    {
        this.gameObject.SetActive(false);
        Helpers.OnGamePause();
    }

    public void RemoveCard(UpgradeCard cardToRemove)
    {
        Helpers.CurrentCard = cardToRemove;
        //Helpers.CurrentCard.IsMaxLevel = true; // makesure we dont miss this
        if (Cards.Contains(Helpers.CurrentCard)) // This should always be true
        { 
            Cards.Remove(Helpers.CurrentCard);
            print($"{cardToRemove} removed ");
        }
    }
}