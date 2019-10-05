using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Wand : MonoBehaviour
{
    [SerializeField] WandData wandData;
    [SerializeField] Transform wandCastPoint;
    float nextCastTime = 0;

    

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump") && CanCast(wandData.Cost) == true) {
            nextCastTime = Time.time + wandData.CooldownTime;
            Instantiate(wandData.WandPrefab, wandCastPoint.position, Quaternion.identity);
            Resources.Instance.UsePower(wandData.Cost);
        }
    }

    private bool CanCast(float Cost) {
        if (Resources.Instance.CanUsePower(Cost) == true && Time.time > nextCastTime) {
            return true;
        }
        else {return false; }
    }
}
