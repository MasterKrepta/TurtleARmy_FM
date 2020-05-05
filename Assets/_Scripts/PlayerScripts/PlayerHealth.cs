using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IHasHealth
{
    [SerializeField] Image image;

    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    bool onCooldown = false;
    [SerializeField] float CooldownTime = 1;

    private void OnEnable() {
        MaxHealth = GetComponent<MinionData>().Data.Health;
        CurrentHealth = MaxHealth;
        image.fillAmount = CurrentHealth / MaxHealth;
    }

    public void TakeDamage(float dmgAmount) {
        if (onCooldown)
            return;

        CurrentHealth -= dmgAmount;
        //TODO fix player flashing
        GetComponentInChildren<FlashOnHit>().FlashColors();
        StartCoroutine("Cooldown");
        UpdateHealthUI();
        if (CurrentHealth <= 0) {
            Helpers.OnPlayerDeath();
            Destroy(gameObject);
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
