using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] float MaxHealth;

    [SerializeField] float currentHealth;

    private void OnEnable() {
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
