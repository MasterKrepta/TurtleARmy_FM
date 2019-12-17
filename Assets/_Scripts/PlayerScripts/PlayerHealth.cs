using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IHasHealth
{
    [SerializeField] Image image;

    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }

    private void OnEnable() {
        MaxHealth = GetComponent<MinionData>().Data.Health;
        CurrentHealth = MaxHealth;
        image.fillAmount = CurrentHealth / MaxHealth;
    }

    public void TakeDamage(float dmgAmount) {
        CurrentHealth -= dmgAmount;
        UpdateHealthUI();
        if (CurrentHealth <= 0) {
            Helpers.OnPlayerDeath();
            Destroy(gameObject);
        }
    }

    private void UpdateHealthUI() {
        image.fillAmount = CurrentHealth / MaxHealth;
    }
}
