using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealMinions : MonoBehaviour
{
    DetectTarget detectTarget;
    Animator anim;
    public float HealTime = 2f;
    public float HealAmount = 3f;
    float nextHealTime;

    private void Awake()
    {
     //   detectTarget = GetComponent<DetectTarget>();
        anim = GetComponentInChildren<Animator>();
        nextHealTime = Time.time + HealTime;
    }
    private void OnEnable()
    {
        //detectTarget.On_AbilityActivate += PeformAction;
    }

    private void OnDisable()
    {
        //detectTarget.On_AbilityActivate -= PeformAction;
    }


    private void Update()
    {
        if (Time.time > nextHealTime)
        {
            nextHealTime = Time.deltaTime + HealTime;
            PeformAction();
        }
    }

    public void PeformAction()
    {
        anim.SetTrigger("Heal");

    }
}
