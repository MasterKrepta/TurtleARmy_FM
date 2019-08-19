using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Resources : MonoBehaviour
{
    public static Resources Instance = null;
    [SerializeField] float EarningRate = 1f;
    
    public int CashOnHand { get; private set; }
    float nextGiveTime;


    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
    }

    private void Update() {
        
        if (Time.time > nextGiveTime) {
            GiveCash();
        }
    }

    void GiveCash() {
        CashOnHand += 1;
            nextGiveTime = Time.time + EarningRate;

    }

    public bool CanAffordCheck(int cost) {
        return CashOnHand >= cost ? true : false;
    }
    public void Pay(int cost) {
        CashOnHand -= cost;
    }
}
