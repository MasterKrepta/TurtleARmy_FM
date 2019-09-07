using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour, IInput
{
    public float Horizontal { get; set; }
    public float Vertical { get; set; }

    public float MoveRight() {
        return 1;
    }
    public float MoveLeft() {
        return -1;
    }

}
