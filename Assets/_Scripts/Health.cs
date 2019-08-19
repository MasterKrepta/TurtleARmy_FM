using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]Image image;
    [SerializeField] float MaxHealth;
    
    [SerializeField]float currentHealth;

    private void OnEnable() {
        try {
            //TODO refactor this code smell
            MaxHealth = GetComponent<Turtle>().Stats.Health;
        }
        catch (Exception) {
            print("Player REFACTOR THIS CODE ALREADY");
            
        }
        
        
        currentHealth = MaxHealth;
        image.fillAmount = currentHealth / MaxHealth;
    }

    public void TakeDamage(int dmgAmount) {
        currentHealth -= dmgAmount;
        UpdateHealthUI();
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }

    private void UpdateHealthUI() {
        image.fillAmount = currentHealth / MaxHealth;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            TakeDamage(1);
        }
    }
}
