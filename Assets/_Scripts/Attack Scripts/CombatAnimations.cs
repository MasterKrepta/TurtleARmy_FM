using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAnimations : MonoBehaviour
{
    [SerializeField] GameObject meleeAttackPoint;
    [SerializeField] GameObject blockAttackPoint;
    public Transform ThrowPoint;
    public GameObject bombPrefab;
    public Transform FlashbangThrowPoint;
    public GameObject FlashbangPrefab;
    public float bombThrowSpeed = 12f;

    public GameObject KamakazeExplosion;

    public GameObject HealEffect;

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

    public void ThrowBomb()
    {
        GameObject go =  Instantiate(bombPrefab, ThrowPoint.position, ThrowPoint.rotation);
        go.GetComponent<Rigidbody>().AddForce(ThrowPoint.forward * bombThrowSpeed, ForceMode.Impulse);
    }

    public void ThrowFlashbang()
    {
        GameObject go = Instantiate(FlashbangPrefab, FlashbangThrowPoint.position, FlashbangThrowPoint.rotation);
        go.GetComponent<Rigidbody>().AddForce(FlashbangThrowPoint.forward * bombThrowSpeed, ForceMode.Impulse);
    }

    public void ActivateKamakaze()
    {
        GameObject go = Instantiate(KamakazeExplosion, transform.position, Quaternion.identity);
        Destroy(go, 1f);
    }

    public void ActivateHeal()
    {
        GameObject go = Instantiate(HealEffect, transform.position, Quaternion.identity);
        Destroy(go, 1f);
    }
}
