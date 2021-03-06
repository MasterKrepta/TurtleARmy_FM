﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    Army Army;
    public KeyCode keycode;
    [SerializeField] bool isUnlocked = false;
    bool onCooldown = false;
    [SerializeField]Image cooldownUI;
    Button button;
    [SerializeField]float cooldownTime = 5f;
    [SerializeField] int Cost = 1;
    // Start is called before the first frame update

    
    void Start()
    {

        Army = FindObjectOfType<Army>().GetComponent<Army>();
        button = GetComponent<Button>();
        if (isUnlocked) {
            EnableButton();
        }
        else {
            button.interactable = false;
        }

    }




    public void DisableButton() {
        if (Resources.Instance.CanAffordCheck_Minion(Cost)) {
            Resources.Instance.BuyMinion(Cost);
            button.interactable = false;
            onCooldown = true;
            int index = int.Parse(this.gameObject.name); // ? This Wont work if the title is changed
            Army.SpawnMinion(index);
        }
   
    }

    public void UnlockMinion() {
        EnableButton();
    }
    



    void EnableButton() {
        cooldownUI.fillAmount = 0;
        button.interactable = true;
    }

    private void Update() {
        if (Input.GetKeyDown(keycode))
        {
            DisableButton();
        }


        if (isUnlocked) { // ! Safty check so we dont enable something we havent unlocked yet 
            //TODO dont even show the button if its not unlocked in start
            CheckForAffordable();
            if (onCooldown) {

                cooldownUI.fillAmount += 1 / cooldownTime * Time.deltaTime;
                if (cooldownUI.fillAmount >= 1) {
                    onCooldown = false;
                    ResetCooldown();
                }
            }
        }
    }

    private void CheckForAffordable() {
        if (Resources.Instance.productionOnHand < Cost) {
            button.interactable = false;
        }
        else {
            button.interactable = true;
        }
    }

    private void ResetCooldown() {
        cooldownUI.fillAmount = 0;
        EnableButton();
    }
}
