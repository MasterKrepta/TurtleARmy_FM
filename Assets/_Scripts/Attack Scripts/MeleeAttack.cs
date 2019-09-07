using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour, IAction
{
    DetectTarget detectTarget;
    Animator anim;

    private void Awake() {
        detectTarget = GetComponent<DetectTarget>();
        anim = GetComponentInChildren<Animator>();
    }
    private void OnEnable() {
        detectTarget.On_AbilityActivate += PeformAction;
    }

    private void OnDisable() {
        detectTarget.On_AbilityActivate -= PeformAction;
    }
    public void PeformAction() {
        //TODO play the animation and use a colider to cause damage
        anim.SetTrigger("MeleeTrigger");
        
    }

  
}
