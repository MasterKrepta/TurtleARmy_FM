using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Resources : MonoBehaviour
{
    public static Resources Instance = null;
    [SerializeField] float ProductionEarningRate = 1f;
    [SerializeField] float MagicEarningRate = .5f;

    public int productionOnHand { get; private set; }
    public float MagicOnHand { get; private set; }
    float nextProductionGiveTime = 0;
    float nextMagicGiveTime = 0;


    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
    }

    private void Update() {
        
        if (Time.time > nextProductionGiveTime) {
            GiveProduction();
        }
        if (Time.time > nextMagicGiveTime) {
            GiveMagic();
        }
    }

    void GiveProduction() {
        productionOnHand += 1;
        nextProductionGiveTime = Time.time + ProductionEarningRate;

    }
    void GiveMagic() {
        MagicOnHand += 1;
        nextMagicGiveTime = Time.time + MagicEarningRate;

    }

    public bool CanAffordCheck_Minion(int cost) {
        return productionOnHand >= cost ? true : false;
    }
    public bool CanUsePower(float cost) {
        return MagicOnHand >= cost ? true : false;
    }
    public void BuyMinion(int cost) {
        productionOnHand -= cost;
    }
    public void UsePower(float cost) {
        MagicOnHand -= cost;
    }
}
