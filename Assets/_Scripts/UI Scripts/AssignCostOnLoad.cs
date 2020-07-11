using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AssignCostOnLoad : MonoBehaviour
{
    [SerializeField] Minion minion;
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Text>().text = minion.CostToSpawn.ToString();
    }


}
