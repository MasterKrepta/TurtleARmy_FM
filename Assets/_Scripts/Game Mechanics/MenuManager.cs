using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void LoadSelectedLevel()
    {
        SceneManager.LoadScene(3);
        //TODO wire up multiple levels per stage
    }
    public void LoadLevelSelect()
    {
        LoadSavePlayerData.Instance.SaveAll();
        SceneManager.LoadScene(2);
    }

    public void LoadStore()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
