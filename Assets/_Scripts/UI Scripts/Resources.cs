using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Resources : MonoBehaviour
{
    public static Resources Instance = null;
    [SerializeField] float CashEarningRate = 1f;
    [SerializeField] float MagicEarningRate = .5f;

    public int CashOnHand { get; private set; }
    public float MagicOnHand { get; private set; }
    float nextCashGiveTime = 0;
    float nextMagicGiveTime = 0;


    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
    }

    private void Update() {
        
        if (Time.time > nextCashGiveTime) {
            GiveCash();
        }
        if (Time.time > nextMagicGiveTime) {
            GiveMagic();
        }
    }

    void GiveCash() {
        CashOnHand += 1;
        nextCashGiveTime = Time.time + CashEarningRate;

    }
    void GiveMagic() {
        MagicOnHand += 1;
        nextMagicGiveTime = Time.time + MagicEarningRate;

    }

    public bool CanAffordCheck_Minion(int cost) {
        return CashOnHand >= cost ? true : false;
    }
    public bool CanUsePower(float cost) {
        return MagicOnHand >= cost ? true : false;
    }
    public void BuyMinion(int cost) {
        CashOnHand -= cost;
    }
    public void UsePower(float cost) {
        MagicOnHand -= cost;
    }
}
