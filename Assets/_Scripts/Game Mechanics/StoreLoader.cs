using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreLoader : MonoBehaviour
{

    [SerializeField] GameObject[] StoreMinions;
    [SerializeField] Minion[] MinionPrefabs;

    [SerializeField] Image SelectedImage;
    [SerializeField] Slider HealthSlider;
    [SerializeField] Slider PowerSlider;
    [SerializeField] Slider SpeedSlider;
    [SerializeField] Slider DelaySlider;
    [SerializeField] Text SelectedName;
    [SerializeField] Text SelectedDescription;
    

    private void OnEnable()
    {
        for (int i = 0; i < StoreMinions.Length; i++)
        {
            //TODO assign Graphic and name
            StoreMinions[i].GetComponentInChildren<Text>().text = $"{MinionPrefabs[i].CurrentUpgrades}/{MinionPrefabs[i].MaxUpgrades}";
            
            if (MinionPrefabs[i].CurrentUpgrades >= MinionPrefabs[i].MaxUpgrades)
            {
                StoreMinions[i].GetComponentInChildren<Button>().interactable = false;
            }
        }
    }

    public void SelectMinion(int index)
    {
        SelectedImage.sprite = StoreMinions[index].GetComponentInChildren<Image>().sprite;
        HealthSlider.value = MinionPrefabs[index].Health / 100;
        PowerSlider.value = MinionPrefabs[index].AttackPower / 100;
        SpeedSlider.value = MinionPrefabs[index].MoveSpeed / 100;
        DelaySlider.value = MinionPrefabs[index].AttackDelay / 100;
        SelectedName.text = MinionPrefabs[index].Name;
        SelectedDescription.text = MinionPrefabs[index].Desc;
    }
}
