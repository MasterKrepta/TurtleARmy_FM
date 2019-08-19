using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject Bullet_PF;
    [SerializeField] Transform barrel;
    [SerializeField] Transform particle;
    EnemyMove enemyMove;

    private void OnEnable() {
        //TODO this wont be reusable for the player REALLY need to refactor it. 
        enemyMove = transform.GetComponentInParent<EnemyMove>();
        enemyMove.On_AbilityActivate += Fire;
    }
    private void OnDisable() {
        enemyMove.On_AbilityActivate -= Fire;
    }

    private void Fire() {
        Instantiate(Bullet_PF, barrel.position, Quaternion.identity);
        
        //print($"Fire for GO: {this.name}");

    }

    //private void SetTag(MoveForward mf) {
    //    mf.enabled = false;
    //    print(this.tag);
    //    if (this.CompareTag("Enemy")) {
    //        mf.Player = false;
    //    }
    //    mf.enabled = true;
    //}
}
