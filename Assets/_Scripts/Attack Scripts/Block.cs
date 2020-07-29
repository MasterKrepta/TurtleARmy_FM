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
        //todo is this smart???
        if (anim.GetBool("Blocking") == true) return;

        
        anim.SetBool("Blocking", true);
        anim.SetTrigger("Activate");
        
    }

    public void CancelBlock() {
        anim.SetBool("Blocking", false);
        
    }


}
