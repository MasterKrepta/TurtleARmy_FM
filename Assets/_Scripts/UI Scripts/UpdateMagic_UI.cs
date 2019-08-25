using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMagic_UI : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Magic: " + Resources.Instance.MagicOnHand;
    }
}
