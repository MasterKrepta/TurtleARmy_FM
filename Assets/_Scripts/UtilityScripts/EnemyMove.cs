using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    

    [SerializeField] float speed = 30f;
    Rigidbody rb;
    DetectTarget detectTarget;



    void Awake()
    {
        detectTarget = GetComponent<DetectTarget>();
        rb = GetComponent<Rigidbody>();
    }
    

    void FixedUpdate()
    {
        if (!detectTarget.TargetLock()) { // if not locked on move
            rb.velocity = transform.forward * speed * Time.deltaTime;
        }
    }

}
