using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasHealth
{
    float MaxHealth { get; set; }
    float CurrentHealth { get; set; }
    void TakeDamage(float amount);
}
