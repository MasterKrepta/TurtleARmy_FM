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
        StartCoroutine("Flash");
        UpdateHealthUI();

        if (CurrentHealth <= 0) {
            
            Destroy(gameObject);
            PlayerProgress.Instance.GiveCredits(5);//TODO credits are hardcoded
            PlayerProgress.Instance.EarnXP(1);
        }

    }

    private void UpdateHealthUI() {
        image.fillAmount = CurrentHealth / MaxHealth;
    }

    IEnumerator Flash()
    {
        if (renderers != null)
        {
            foreach (Renderer r in renderers)
            {
                r.material.SetColor("_BaseColor", HitColor);
            }

            yield return new WaitForSeconds(flashTime);

            foreach (Renderer r in renderers)
            {
                if (r != null)
                {
                    for (int i = 0; i < renderers.Length; i++)
                    {
                        renderers[i].material.SetColor("_BaseColor", originals[i]);

                    }

                }
            }
        }

    }

    void GetOriginalColors()
    {

        for (int i = 0; i < renderers.Length; i++)
        {
            originals[i] = renderers[i].material.color;
        }
    }


}
