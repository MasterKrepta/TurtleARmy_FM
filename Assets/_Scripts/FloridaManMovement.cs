using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloridaManMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    Rigidbody rb;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }


    private void FixedUpdate() {
        rb.velocity = transform.forward * moveSpeed * Time.deltaTime;
    }
}
