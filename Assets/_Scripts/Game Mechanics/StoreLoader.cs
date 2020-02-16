using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreLoader : MonoBehaviour
{

    [SerializeField] Button upgradeButton;
    [SerializeField] Text currentMoney;
    [SerializeField] Text CosttoBuy;
    [SerializeField] Money Money;
    [SerializeField] GameObject[] StoreMinions;
    [SerializeField] Minion[] MinionPrefabs;

    [SerializeField] Image SelectedImage;
    [SerializeField] Slider HealthSlider;
    [SerializeField] Slider PowerSlider;
    [SerializeField] Slider SpeedSlider;
    [SerializeField] Slider DelaySlider;
    [SerializeField] Text SelectedName;
    [SerializeField] Text SelectedDescription;
    int selected = 0;
    bool _canBuy = false;



    private void OnEnable()
    {
        for (int i = 0; i < StoreMinions.Length; i++)
        {
            RefreshUI(i);
        }

        ////TODO remove this after testing
        //Money.CurrentMoney = Money.StartingMoney;

        SelectMinion(selected);
    }

    bool canBuy()
    {
        var cost = MinionPrefabs[selected].CostToUpgrade;
        if (Money.CurrentMoney >= cost && MinionPrefabs[selected].CurrentUpgrades < MinionPrefabs[selected].MaxUpgrades)
        {
            upgradeButton.interactable = true;
            return true;
        }
        else
        {
            upgradeButton.interactable = false;
            return false;
        }

    }
    public void SelectMinion(int index)
    {
        selected = index;
        SelectedImage.sprite = StoreMinions[index].GetComponentInChildren<Image>().sprite;
        HealthSlider.value = MinionPrefabs[index].Health / 100;
        PowerSlider.value = MinionPrefabs[index].AttackPower / 100;
        SpeedSlider.value = MinionPrefabs[index].MoveSpeed / 100;
        DelaySlider.value = MinionPrefabs[index].AttackDelay / 100;
        SelectedName.text = MinionPrefabs[index].Name;
        SelectedDescription.text = MinionPrefabs[index].Desc;
        _canBuy = canBuy();
        RefreshUI(selected);
   
    }

    public void BuyUpgrade(int index)
    {
        index = selected; //TODO might be a better way to do this.
        var minion = MinionPrefabs[selected];

        Money.CurrentMoney -= minion.CostToUpgrade;
        minion.CostToUpgrade *= minion.CostIncreasePerUpgrade;
        minion.CurrentUpgrades++;

        MinionPrefabs[index].Health += minion.UpgradeHealth;
        MinionPrefabs[index].AttackPower += minion.UpgradeAttackPower;
        MinionPrefabs[index].MoveSpeed += minion.UpgradeSpeed;
        
        //TODO  clamping is currently untested
        Mathf.Clamp(minion.AttackDelay -= minion.UpgradeAttackDelay, minion.MinAttackDelay, minion.AttackDelay);

        
        _canBuy = canBuy();
        RefreshUI(selected);
    }

    void RefreshUI(int i)
    {
        StoreMinions[i].GetComponentInChildren<Text>().text = $"{MinionPrefabs[i].CurrentUpgrades}/{MinionPrefabs[i].MaxUpgrades}";

        if (MinionPrefabs[i].CurrentUpgrades >= MinionPrefabs[i].MaxUpgrades)
        {
            StoreMinions[i].GetComponentInChildren<Button>().interactable = false;
        }

        currentMoney.text = Money.CurrentMoney.ToString();
        CosttoBuy.text = MinionPrefabs[i].CostToUpgrade.ToString();
    }
}
