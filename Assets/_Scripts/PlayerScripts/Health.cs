using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IHasHealth
{
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }

    [SerializeField] Image image;
    bool onCooldown = false;
    [SerializeField] float CooldownTime = 1;

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
        if (onCooldown)
            return;
        
        CurrentHealth -= dmgAmount;
        StartCoroutine("Cooldown");
        GetComponentInChildren<FlashOnHit>().FlashColors();
        UpdateHealthUI();
        if (CurrentHealth <= 0) {
            Destroy(gameObject);
            PlayerProgress.Instance.GiveCredits(5);
        }
    }

    private void UpdateHealthUI() {
        image.fillAmount = CurrentHealth / MaxHealth;
    }

    IEnumerator Cooldown()
    {
        //print($"{name} is on cooldown");
        onCooldown = true;
        yield return new WaitForSeconds(CooldownTime);
        onCooldown = false;
        //print($"{name} is off cooldown");
    }

    public void HealDamage(float healAmount)
    {
        print($"{ this.gameObject.name} has been healed");
        CurrentHealth += healAmount;
    }
}
