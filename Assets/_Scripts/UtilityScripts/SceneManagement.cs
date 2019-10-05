//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public static class SceneManagement
{
    public static int CurrentLevel = 0;
    public static Action OnLevelOver = delegate{ };

 
    public static void LoadNextLevel(int currentLevel) {
        SceneManager.LoadScene(currentLevel);
    }
}
