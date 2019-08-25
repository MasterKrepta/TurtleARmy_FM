using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IHasHealth
{
    [SerializeField] Image image;
    [SerializeField] float MaxHealth;

    [SerializeField] float currentHealth;

  
    private void OnEnable() {
        try {
            //TODO refactor this code smell figure out how to use the data.
            MaxHealth = GetComponent<Turtle>().Stats.Health;
        }
        catch (Exception) {
            Debug.LogWarning($"{gameObject.name} REFACTOR: There is no Data structure on this gameobject");

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

 
}
