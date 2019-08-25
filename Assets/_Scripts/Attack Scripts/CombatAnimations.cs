using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAnimations : MonoBehaviour
{
    [SerializeField] GameObject meleeAttackPoint;
    [SerializeField] GameObject blockAttackPoint;

    public void MeleeAttack_On() {
        meleeAttackPoint.SetActive(true);
    }
    public void MeleeAttack_Off() {
        meleeAttackPoint.SetActive(false);
    }

    public void Block_On() {
        blockAttackPoint.SetActive(true);
    }
    public void Block_Off() {
        blockAttackPoint.SetActive(false);
    }
}
