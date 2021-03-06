﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class FloridaManMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    float dirX;
    Rigidbody rb;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update() {
        

        dirX = CrossPlatformInputManager.GetAxis("Horizontal");
    }
    

    private void FixedUpdate() 
    {
        if (Helpers.Paused) { return; }
        if (dirX != 0)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }
        rb.velocity = new Vector3(0, rb.velocity.y, dirX * moveSpeed);
        RotatePlayer();
        
    }

     private void RotatePlayer() {
        if (dirX > 0) {
            transform.rotation = Quaternion.Euler(0f, 0, 0f);
        }
        else if (dirX < 0) {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);

        }
    }


}
