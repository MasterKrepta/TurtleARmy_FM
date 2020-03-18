using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    public WandData wandData;
    [SerializeField] Transform wandCastPoint;
    float nextCastTime = 0;

    Animator anim;


    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Helpers.Paused) { return; }

        if (Input.GetButtonDown("Jump")){
            BeginCastWand();
                
            //FireButton();
        }
    }

    private bool CanCast(float Cost) {
        if (Resources.Instance.CanUsePower(Cost) == true && Time.time > nextCastTime) {
            return true;
        }
        else {return false; }
    }
    
    public void BeginCastWand()
    {
        if (CanCast(wandData.Cost) == true)
        {
            anim.SetTrigger("WandAttack");
        }
    }

    public void FireButton()
    {

            nextCastTime = Time.time + wandData.CooldownTime;
            Instantiate(wandData.WandPrefab, wandCastPoint.position, Quaternion.identity);
            Resources.Instance.UsePower(wandData.Cost);
    }
}
