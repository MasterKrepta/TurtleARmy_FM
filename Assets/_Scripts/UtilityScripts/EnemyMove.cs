using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody rb;
    DetectTarget detectTarget;

  
    void Awake()
    {
        speed = GetComponent<MinionData>().Data.Movespeed;
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
