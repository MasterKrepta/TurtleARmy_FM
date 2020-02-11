using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Money", menuName = "ScriptableObjects/Money", order = 1)]
public class Money : ScriptableObject
{
    public float StartingMoney = 100f;
    public float CurrentMoney = 100f;

}
