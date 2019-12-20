using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
    public static bool Paused = false;
    public static bool GameOver = false;
    public static Action OnGamePause =() => { PauseToggle(); };
    public static Action OnPlayerDeath = () => { CallGameOver(); };
    public static Action OnLevelUp = () => { LevelUpCalled(); };
    public static Action OnResetCards = () => { };
    public static UpgradeCard CurrentCard;


    static void PauseToggle()
    {
        
        Paused = !Paused;

        if (Paused) { Time.timeScale = 0;} else{ Time.timeScale = 1;}
        //Debug.Log($"Paused value is: {Paused}");
    }
    static void CallGameOver()
    {
        GameOver = true;
    }
    static void LevelUpCalled()
    {

    }
}
