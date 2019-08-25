using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] float moveSpeed = 25;
    [SerializeField] float lifeTime = 2f;
    public bool Player { private get; set; }


    private void OnEnable() {
        if (CompareTag("Player") ){
            Player = true;
        }
        if (!Player) {
            moveSpeed *= -1;
        }
    }
    void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        Destroy(gameObject, lifeTime);
    }
}
