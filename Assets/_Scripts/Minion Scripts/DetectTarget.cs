using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTarget : MonoBehaviour
{
    public Action On_AbilityActivate = delegate { };
    public Action On_AbiltyDeactivate = delegate{};

    [Space(15)]
    [SerializeField] float detectRadius = 20;
    [SerializeField] LayerMask hitLayer;
    bool targetLock = false;
    [SerializeField] float AbilityDelay = 1.5f;
    float nextAbility;
    
    void Start()
    {
        //SetDetectRadius();
        //TODO set up radius automatically based on data - need to refactor for the enemies. 
    }

    private void SetDetectRadius() {
        //TODO research bitwise ops for this. 
        
        if (this.CompareTag("Enemy")) {
            hitLayer = ~8;
            
        }
        else {
            hitLayer = ~9;
        }

        Debug.Log(hitLayer);
    }

    void FixedUpdate()
    {
        

        RaycastHit hit;


        //TODO DEBUG THIS. Enemy stops shooting when we are very close
        //TODO change this to include anyone on the other layer so it we stop and attack no matter what. 
        //print($"{gameObject.name} is looking for layer {hitLayer.value}");

        //todo the radius is causing an issue with the kamakaze character detection. 
        if (Physics.SphereCast(transform.position, detectRadius / 2, transform.forward, out hit, detectRadius/2, hitLayer))
        {
            if (hit.collider.GetComponent<IHasHealth>() == null)
                return;

            targetLock = true;
            //Debug.Log($"{this.name} has hit {hit.transform.name}");
            if (Time.time >= nextAbility)
            {
                On_AbilityActivate();
                ResetAbility();
            }


        }
        else {
            targetLock = false;
            On_AbiltyDeactivate();
        }

    }


    private void ResetAbility() {
        nextAbility = Time.time + AbilityDelay;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }

    public bool TargetLock() {
        return targetLock;
    }
}
