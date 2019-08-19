using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Turtle : MonoBehaviour
{

    [SerializeField] Minion stats;
    Rigidbody rb;
    float speed;

    public Minion Stats => stats;
    public enum turtleState
    {
        MOVING, ATTACKING, DEAD
    }
    public turtleState TurtleState = turtleState.MOVING;

    private void Awake() {
        speed = stats.Movespeed;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        switch (TurtleState) {
            case turtleState.MOVING:
                rb.velocity = transform.forward * speed * Time.deltaTime;
                break;
            case turtleState.ATTACKING:
                break;
            case turtleState.DEAD:
                break;
            default:
                break;
        }
    }
}
