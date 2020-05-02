using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverLifetime : MonoBehaviour
{
    
    float lifetime = 1;
    float buffer = 0.2f;

    private void OnEnable()
    {
        lifetime = GetComponent<Bomb>().explodeTime + buffer;
    }
    void Start()
    {
        
        Destroy(this.gameObject, lifetime);
    }

    
}
