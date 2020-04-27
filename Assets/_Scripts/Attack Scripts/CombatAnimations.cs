using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAnimations : MonoBehaviour
{
    [SerializeField] GameObject meleeAttackPoint;
    [SerializeField] GameObject blockAttackPoint;
    [SerializeField] Wand Wand;

    public void MeleeAttack_On() {
        meleeAttackPoint.SetActive(true);
        meleeAttackPoint.GetComponent<Collider>().enabled = true;
    }
    public void MeleeAttack_Off() {
        meleeAttackPoint.SetActive(false);
        meleeAttackPoint.GetComponent<Collider>().enabled = false;
    }

    public void Block_On() {
        blockAttackPoint.SetActive(true);
        blockAttackPoint.GetComponent<Collider>().enabled = true;
    }
    public void Block_Off() {
        blockAttackPoint.SetActive(false);
        blockAttackPoint.GetComponent<Collider>().enabled = false;
    }

    public void FireWandAttack()
    {
        Wand.FireButton();
    }
}
