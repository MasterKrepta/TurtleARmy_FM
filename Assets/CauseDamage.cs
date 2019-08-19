using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauseDamage : MonoBehaviour
{
    [SerializeField] int dmgAmount = 1;
    private void OnTriggerEnter(Collider other) {
        Health otherHealth = other.GetComponent<Health>();
        if (otherHealth != null) {
            otherHealth.TakeDamage(dmgAmount);
            Destroy(gameObject);
        }
        
    }
}
