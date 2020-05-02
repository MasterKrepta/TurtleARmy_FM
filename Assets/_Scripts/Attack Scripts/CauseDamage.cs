using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauseDamage : MonoBehaviour
{
    [SerializeField] int dmgAmount = 1;
    
    private void OnTriggerEnter(Collider other) {
        IHasHealth otherHealth = other.GetComponent<IHasHealth>();
        
        if (otherHealth != null && other.tag != gameObject.tag) {
            otherHealth.TakeDamage(dmgAmount);
            //print($"{this.name} hits {other.name} and causes damage");
            //Destroy(gameObject);
        }
        else
        {
            //print($"No damage from {this.name} hits {other.name}");
        }
        
    }
}
