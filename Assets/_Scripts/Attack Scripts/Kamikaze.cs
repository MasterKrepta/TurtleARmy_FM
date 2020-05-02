using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : MonoBehaviour, IAction
{
    public GameObject kamikazePrefab;

    DetectTarget detectTarget;
    Animator anim;

    private void Awake()
    {
        detectTarget = GetComponent<DetectTarget>();
        anim = GetComponentInChildren<Animator>();
    }
    private void OnEnable()
    {
        detectTarget.On_AbilityActivate += PeformAction;
    }

    private void OnDisable()
    {
        detectTarget.On_AbilityActivate -= PeformAction;
    }

    public void PeformAction()
    {
        Collider[] cols = GetComponents<Collider>();
        GetComponent<Rigidbody>().useGravity = false;
        foreach (var c in cols)
        {
            c.enabled = false;
        }

        anim.SetTrigger("Kamakaze");
        Destroy(this.gameObject, 2f); //TODO not safe
        
    }


}
