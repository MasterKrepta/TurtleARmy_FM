using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauseWandDamage : MonoBehaviour
{
    [SerializeField] int dmgAmount = 1;
    [SerializeField] int durability = 3;

    private void Awake() {
        //todo Need to set this up using the data from the player automatically. 
        Destroy(gameObject, 1.5f);
    }
    private void OnTriggerEnter(Collider other) {
        IHasHealth otherHealth = other.GetComponent<IHasHealth>();
        if (otherHealth != null && other.tag != gameObject.tag) {
            otherHealth.TakeDamage(dmgAmount);
            durability--;
            if (durability <=0) {
                Destroy(gameObject);
            }
            
        }

    }
}
