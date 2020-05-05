using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : MonoBehaviour
{
    [SerializeField] int healAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        
        IHasHealth otherHealth = other.GetComponent<IHasHealth>();

        if (otherHealth != null && other.tag != gameObject.tag)
        {
            otherHealth.HealDamage(healAmount);
            //print($"{this.name} hits {other.name} and causes damage");
            Destroy(gameObject);
        }
        else
        {
            //print($"No damage from {this.name} hits {other.name}");
        }

    }
}
