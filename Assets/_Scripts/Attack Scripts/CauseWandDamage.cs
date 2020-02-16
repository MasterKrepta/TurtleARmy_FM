using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauseWandDamage : MonoBehaviour
{
    [SerializeField] float dmgAmount = 1;
    [SerializeField] int durability = 3;
    [SerializeField] Minion FlordaMan_Data;

    private void Awake() {
        //todo Need to set this up using the data from the player automatically. 
        
        Destroy(gameObject, 1.5f);
    }
    private void Update()
    {
        //TODo this is horrible, Get it out of updagte lets test it (seems to not be working
        dmgAmount = FlordaMan_Data.AttackPower;
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
