using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, IAction
{
    DetectTarget detectTarget;
    Animator anim;

    private void Awake() {
        detectTarget = GetComponent<DetectTarget>();
        anim = GetComponentInChildren<Animator>();
    }
    private void OnEnable() {
        detectTarget.On_AbilityActivate += PeformAction;
        detectTarget.On_AbiltyDeactivate += CancelBlock;
    }

    private void OnDisable() {
        detectTarget.On_AbilityActivate -= PeformAction;
        detectTarget.On_AbiltyDeactivate -= CancelBlock;
    }
    public void PeformAction() {
        anim.SetBool("Blocking", true);
        
    }

    public void CancelBlock() {
        anim.SetBool("Blocking", false);
    }


}
