using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public float explodeTime = 2f;
    public GameObject particle;

    private void Start()
    {
        Invoke("Explode", explodeTime);
    }

    void Explode()
    {
        //collider.enabled = true;
        GameObject go = Instantiate(particle, transform.position, Quaternion.identity);
        //go.GetComponent<AudioSource>().Play();
        Destroy(go, 1f);
        
    }

}
