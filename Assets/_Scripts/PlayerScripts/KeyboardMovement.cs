using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour, IInput
{
    public float Horizontal { get ; set ; }
    public float Vertical { get; set; }

    public void Update() {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
    }


}
