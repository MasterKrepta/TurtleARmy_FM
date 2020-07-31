using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class TurtleMovement : MonoBehaviour
{
    Rigidbody rb;
    float speed;
    DetectTarget detectTarget;

    private void OnEnable() {
        detectTarget = transform.GetComponentInParent<DetectTarget>();
    }
    private void Awake() {
        speed = GetComponent<MinionData>().Data.MoveSpeed;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() 
    {
        if (Helpers.Paused) { return; }

        if (!detectTarget.TargetLock()) { // if not locked on move
            rb.velocity = transform.forward * speed * Time.deltaTime;
        }
  
    }
}