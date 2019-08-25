using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloridaManMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Rigidbody rb;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void GetInput() {

    }

    private void FixedUpdate() {
        //rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * (moveSpeed),
        //      rb.velocity.y,
        //      Input.GetAxisRaw("Vertical") * (moveSpeed));
        rb.velocity = new Vector3(0, rb.velocity.y, Input.GetAxisRaw("Horizontal") * moveSpeed);
        RotatePlayer();
        
    }

     private void RotatePlayer() {
        if (Input.GetAxisRaw("Horizontal") > 0) {
            transform.rotation = Quaternion.Euler(0f, 0, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0) {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);

        }
    }
}
