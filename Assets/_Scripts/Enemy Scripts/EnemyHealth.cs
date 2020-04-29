using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IHasHealth
{
    [SerializeField] Image image;

    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }

    [SerializeField] GameObject parentRenderer;
    [SerializeField] Color HitColor = Color.red;
    [SerializeField] Color[] originals = new Color[5]; //TODO  Evaluate this number, it should not be this large in the final game. 
    Renderer[] renderers;
    float flashTime = 0.2f;

    private void OnEnable()
    {
        try
        {
            MaxHealth = GetComponent<MinionData>().Data.Health;
        }
        catch (Exception)
        {
            Debug.LogWarning($"{gameObject.name} REFACTOR: There is no Data structure on this gameobject");

        }


        CurrentHealth = MaxHealth;
        image.fillAmount = CurrentHealth / MaxHealth;
    }

    public void TakeDamage(float dmgAmount)
    {
        CurrentHealth -= dmgAmount;
        GetComponentInChildren<FlashOnHit>().FlashColors();
        //Helpers.OnTakeDamage(this.transform.root.gameObject);
        UpdateHealthUI();

        if (CurrentHealth <= 0)
        {

            Destroy(gameObject);
            PlayerProgress.Instance.GiveCredits(5);//TODO credits are hardcoded
            PlayerProgress.Instance.EarnXP(1);
        }

    }

    private void UpdateHealthUI()
    {
        image.fillAmount = CurrentHealth / MaxHealth;
    }
}