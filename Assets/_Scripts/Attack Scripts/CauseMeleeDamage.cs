using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauseMeleeDamage : MonoBehaviour
{
    [SerializeField] int dmgAmount = 1;

    private void OnTriggerEnter(Collider other) {
        IHasHealth otherHealth = other.GetComponent<IHasHealth>();
        if (otherHealth != null && other.tag != gameObject.tag) {
            otherHealth.TakeDamage(dmgAmount);
        }
    }
}
