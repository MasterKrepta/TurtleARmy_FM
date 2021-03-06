﻿using System;
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
        //research bitwise ops for this. 
        print("setting radius");
        if (this.CompareTag("Enemy")) {
            hitLayer = ~8;
            
        }
        else {
            hitLayer = ~9;
        }

        Debug.Log(hitLayer.value);
    }

    void FixedUpdate()
    {
        

        RaycastHit hit;


        //TODO change this to include anyone on the other layer so it we stop and attack no matter what. 
        //print($"{gameObject.name} is looking for layer {hitLayer.value}");

        //todo the radius is causing an issue with the kamakaze character detection. 
        if (Physics.SphereCast(transform.position, detectRadius / 2, transform.forward, out hit, detectRadius/2, hitLayer))
        {
            if (hit.collider.GetComponent<IHasHealth>() == null)
                return;
            EnableTargetLock();
            //Debug.Log($"{this.name} has hit {hit.transform.name}");
            if (Time.time >= nextAbility)
            {
                On_AbilityActivate();
                ResetAbility();
            }
        }
        else {
            DisableTargetLock();
            On_AbiltyDeactivate();
        }

    }

    public void EnableTargetLock()
    {
        targetLock = true;
    }
    public void DisableTargetLock()
    {
        targetLock = false;
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
