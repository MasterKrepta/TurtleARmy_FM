using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetroyOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject, 0.10f);
    }
}
