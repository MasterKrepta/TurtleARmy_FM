using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody rb;
    DetectTarget detectTarget;


    private void OnEnable()
    {

    }

    void Awake()
    {
        speed = GetComponent<MinionData>().Data.MoveSpeed;
        detectTarget = GetComponent<DetectTarget>();
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        if (Helpers.Paused) { return; }

        if (!detectTarget.TargetLock())
        { // if not locked on move
            rb.velocity = transform.forward * speed * Time.deltaTime;
        }
    }
}

   
