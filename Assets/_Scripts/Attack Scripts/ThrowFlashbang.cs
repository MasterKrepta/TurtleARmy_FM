using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFlashbang : MonoBehaviour
{
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
        anim.SetTrigger("ThrowFlashbang");

    }
}
