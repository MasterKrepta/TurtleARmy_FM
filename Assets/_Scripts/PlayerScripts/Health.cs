using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IHasHealth
{
    [SerializeField] Image image;

    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }

    private void OnEnable() {
        try {
            MaxHealth = GetComponent<MinionData>().Data.Health;
        }
        catch (Exception) {
            Debug.LogWarning($"{gameObject.name} REFACTOR: There is no Data structure on this gameobject");

        }
        

        CurrentHealth = MaxHealth;
        image.fillAmount = CurrentHealth / MaxHealth;
    }

    public void TakeDamage(float dmgAmount) {
        CurrentHealth -= dmgAmount;
        UpdateHealthUI();
        if (CurrentHealth <= 0) {
            Destroy(gameObject);
        }
    }

    private void UpdateHealthUI() {
        image.fillAmount = CurrentHealth / MaxHealth;
    }

 
}
