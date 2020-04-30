
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public static class SceneManagement
{
    public static int CurrentLevel = 2; //TODO change this with level select system
    public static Action OnLevelOver = delegate { };


    public static void LoadNextLevel()
    {
        SceneManager.LoadScene(CurrentLevel);
    }

    public static void LoadSelectedLevel(int id)
    {
        SceneManager.LoadScene(CurrentLevel);
    }
}