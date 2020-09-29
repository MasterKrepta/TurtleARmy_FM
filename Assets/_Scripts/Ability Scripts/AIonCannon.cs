using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIonCannon : MonoBehaviour
{
    public float fireTime = 1f;
    public float dmgAmount = 1f;
    public float moveSpeed = 1.25f;


    private void Awake()
    {
        Destroy(this.gameObject, fireTime);
        transform.position = new Vector3(transform.position.x, 5.4f, transform.position.z);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed* Time.deltaTime);
    }
    private void OnTriggerStay(Collider other)
    {
        IHasHealth otherHealth = other.GetComponent<IHasHealth>();

        if (otherHealth != null && other.tag != gameObject.tag)
        {
            otherHealth.TakeDamage(dmgAmount);
            //print($"{this.name} hits {other.name} and causes damage");
            
        }
    }
}
