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

    [SerializeField] GameObject parentRenderer;
    [SerializeField]Color HitColor = Color.red;
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

        renderers = parentRenderer.GetComponentsInChildren<Renderer>();
        GetOriginalColors();
    }

    public void TakeDamage(float dmgAmount) {
        if (onCooldown)     
            return;
        
        CurrentHealth -= dmgAmount;
        StartCoroutine("Cooldown");
        StartCoroutine("Flash");
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
    IEnumerator Flash()
    {

        
        foreach (Renderer r in renderers)
        {
            print(r.material.color.ToString());
            r.material.SetColor("_BaseColor", HitColor);
            print(r.material.color.ToString() + " After");
        }

        yield return new WaitForSeconds(flashTime);

        foreach (Renderer r in renderers)
        {
            if (r != null)
            {
                for (int i = 0; i < renderers.Length; i++)
                {
                    renderers[i].material.SetColor("_BaseColor",  originals[i]);
                    
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
