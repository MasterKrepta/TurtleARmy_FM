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

    [SerializeField] GameObject parentRenderer;
    [SerializeField] Color HitColor = Color.red;
    [SerializeField] Color[] originals = new Color[5]; //TODO  Evaluate this number, it should not be this large in the final game. 
    Renderer[] renderers;
    float flashTime = 0.2f;


    private void OnEnable()
    {
        renderers = parentRenderer.GetComponentsInChildren<Renderer>();
        GetOriginalColors();
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
        StartCoroutine("Flash");
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
        Countdown.gameObject.SetActive(true);
        StartCoroutine(BeginLevelCountdown());

    }

    IEnumerator BeginLevelCountdown()
    {

        yield return new WaitForSeconds(countdownTime);
        //TODO Manage Level progression
        SceneManagement.LoadNextLevel(2);

        //SceneManagement.CurrentLevel++;
        //if (SceneManagement.CurrentLevel > UnityEngine.SceneManagement.SceneManager.sceneCount)
        //{
        //    SceneManagement.CurrentLevel = 0;

        //}
        //SceneManagement.LoadNextLevel(SceneManagement.CurrentLevel);

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