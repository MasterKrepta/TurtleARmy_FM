using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Turtle : MonoBehaviour
{
    Rigidbody rb;
    float speed;

    



  
    public enum turtleState
    {
        MOVING, ATTACKING, DEAD
    }
    public turtleState TurtleState = turtleState.MOVING;

    DetectTarget detectTarget;

    private void OnEnable() {
        detectTarget = transform.GetComponentInParent<DetectTarget>();
        
    }
    private void OnDisable() {
        
    }
    private void Awake() {
        speed = GetComponent<MinionData>().Data.MoveSpeed;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() 
    {
        if (Utilities.Paused) { return; }

        if (!detectTarget.TargetLock()) { // if not locked on move
            rb.velocity = transform.forward * speed * Time.deltaTime;
        }
        //    switch (TurtleState) {
        //    case turtleState.MOVING:
        //        rb.velocity = transform.forward * speed * Time.deltaTime;
        //        break;
        //    case turtleState.ATTACKING:
        //        break;
        //    case turtleState.DEAD:
        //        break;
        //    default:
        //        break;
        //}
    }

    
}
