using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static bool Paused = false;
    public static Action OnGamePause =() => { PauseToggle(); };

    static void PauseToggle()
    {
        Paused = !Paused;
    }
}
