using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour, IAction
{
    [SerializeField] GameObject Bullet_PF;
    [SerializeField] Transform barrel;
    [SerializeField] Transform particle;
    DetectTarget detectTarget;

    private void Awake() {
        detectTarget = transform.GetComponentInParent<DetectTarget>();
    }
    private void OnEnable() {
        
        detectTarget.On_AbilityActivate += PeformAction;
    }
    private void OnDisable() {
        detectTarget.On_AbilityActivate -= PeformAction;
    }

    public void PeformAction() {
        Instantiate(Bullet_PF, barrel.position, Quaternion.identity);

        //print($"Fire for GO: {this.name}");
    }

}
