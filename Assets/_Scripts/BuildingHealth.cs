using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class BuildingHealth : MonoBehaviour, IHasHealth
{
    [SerializeField] Text Countdown;
    int countdownTime = 3;
    float currentTime = 3;
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }

    [SerializeField] Image image;

    private void OnEnable() {
        Countdown.enabled = false;
        try {
            MaxHealth = GetComponent<MinionData>().Data.Health;
        }
        catch (Exception) {
            Debug.LogWarning($"{gameObject.name} REFACTOR: There is no Data structure on this gameobject");

        }


        CurrentHealth = MaxHealth;
        image.fillAmount = CurrentHealth / MaxHealth;
    }
    public void TakeDamage(float amount) {
        
        CurrentHealth -= amount;
        UpdateHealthUI();
        if (CurrentHealth <= 0) {
            LevelEnd();
        }
    }

    private void UpdateHealthUI() {
        image.fillAmount = CurrentHealth / MaxHealth;
    }

    void Update() {
        if (Countdown.enabled) {
            Countdown.text = (currentTime -= Time.deltaTime).ToString();
        }
    }
    private void LevelEnd() {
        SceneManagement.OnLevelOver();
        this.GetComponent<BoxCollider>().enabled = false;
        Countdown.enabled = true;
        StartCoroutine(BeginLevelCountdown());

    }

    IEnumerator BeginLevelCountdown() {
        
        yield return new WaitForSeconds(countdownTime);
        //TODO Manage Level progression
        SceneManagement.CurrentLevel++;
        if (SceneManagement.CurrentLevel > UnityEngine.SceneManagement.SceneManager.sceneCount) {
            SceneManagement.CurrentLevel = 0;
            
        }
        SceneManagement.LoadNextLevel(SceneManagement.CurrentLevel);
        
    }

    
}
