using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class BuildingHealth : MonoBehaviour, IHasHealth
{
    [SerializeField] Text Countdown;
    [SerializeField] LevelData levelData;
    int countdownTime = 5;
    float currentTime = 5;
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }

    [SerializeField] Image image;

    private void OnEnable()
    {
        Countdown.enabled = false;
        try
        {
            MaxHealth = levelData.BaseHealth;
        }
        catch (Exception)
        {
            Debug.LogWarning($"{gameObject.name} REFACTOR: There is no Data structure on this gameobject");

        }


        CurrentHealth = MaxHealth;
        image.fillAmount = CurrentHealth / MaxHealth;
    }
    public void TakeDamage(float amount)
    {

        CurrentHealth -= amount;
        UpdateHealthUI();
        if (CurrentHealth <= 0)
        {
            LevelEnd();
        }
    }

    private void UpdateHealthUI()
    {
        image.fillAmount = CurrentHealth / MaxHealth;
    }

    void Update()
    {
        if (Countdown.enabled)
        {
            Countdown.text = $"Next Level Starts in: {Mathf.FloorToInt(currentTime -= Time.deltaTime).ToString()}";
            if (currentTime <=0)
            {
                Countdown.enabled = false;
            }
        }
    }
    private void LevelEnd()
    {
        SceneManagement.OnLevelOver();
        this.GetComponent<BoxCollider>().enabled = false;
        Countdown.enabled = true;
        StartCoroutine(BeginLevelCountdown());

    }

    IEnumerator BeginLevelCountdown()
    {

        yield return new WaitForSeconds(countdownTime);
        //TODO Manage Level progression
        SceneManagement.CurrentLevel++;
        if (SceneManagement.CurrentLevel > UnityEngine.SceneManagement.SceneManager.sceneCount)
        {
            SceneManagement.CurrentLevel = 0;

        }
        SceneManagement.LoadNextLevel(SceneManagement.CurrentLevel);

    }


}