using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public UpgradeCard cardData;
    [SerializeField]Image buttonImg;
    [SerializeField]Text buttonText;

    private void Awake()
    {
        buttonImg = transform.GetChild(1).GetComponentInChildren<Image>();
        buttonText = GetComponentInChildren<Text>();
    }
    
    public void Init(UpgradeCard _cardData)
    {
        if (_cardData == null)
        {
            Debug.LogError("DATA is missing");
        }
        buttonImg.sprite = _cardData.Icon;
        cardData = _cardData;
        cardData.ConfigureCardText(); 
        buttonText.text = cardData.Text;
    }
    public void Use(UpgradeCard selectedCard)
    {
        cardData.ApplyUpgrade(selectedCard);
    }
}
