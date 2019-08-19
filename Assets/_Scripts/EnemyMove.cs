using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Action On_AbilityActivate;

    [SerializeField] float speed = 30f;
    Rigidbody rb;
    

    //TODO refactor out the attack code. 
    [Space(15)]
    [SerializeField] float detectRadius = 15;
    [SerializeField] LayerMask layer;
    bool targetLock = false;
    [SerializeField] float shootDelay = 1.5f;
    float nextShot;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void Update() {
        DetectTarget();
    }

    private void DetectTarget() {
        RaycastHit hit;

        
        //TODO DEBUG THIS
        if (Physics.SphereCast(transform.position, detectRadius, -transform.forward, out hit, detectRadius/2)) {
            Debug.Log($"{this.name} has hit {hit.transform.name}");
            targetLock = true;
            if (Time.time >= nextShot) {
                On_AbilityActivate();
                ResetShot();
            }

        } else {
            targetLock = false;
        }
      
    }

    private void ResetShot() {
        nextShot = Time.time + shootDelay;
    }

    void FixedUpdate()
    {
        if (targetLock == false) {
            rb.velocity = transform.forward * speed * Time.deltaTime;
        }
        else {

        }
        
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawSphere(transform.position, detectRadius);
    }
}
