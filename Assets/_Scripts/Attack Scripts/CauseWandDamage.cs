using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauseWandDamage : MonoBehaviour
{
    [SerializeField] float dmgAmount = 1;
    [SerializeField] int durability = 3;
    [SerializeField] Minion FlordaMan_Data;

    private void Awake() {
        dmgAmount = FlordaMan_Data.AttackPower;
        Destroy(gameObject, 1.5f);
    }
    private void OnTriggerEnter(Collider other) {
        IHasHealth otherHealth = other.GetComponent<IHasHealth>();
        if (otherHealth != null && other.tag != gameObject.tag) {
            otherHealth.TakeDamage(dmgAmount);
            
            //! use this if we dont have durability Destroy(gameObject);
            //Destroy(gameObject);

            durability--;
            if (durability <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
