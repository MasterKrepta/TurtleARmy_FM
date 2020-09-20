using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkills : MonoBehaviour
{
    [SerializeField] Button[] _buttons = new Button[3];
    [SerializeField]Ability[] _abilities = new Ability[3] ;

    // Start is called before the first frame update
    private void Start()
    {
        foreach (var b in _buttons)
        {
            b.enabled = false;
            
        }
    }
    private void Update()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].enabled = CanUse(_abilities[i]);
            _buttons[i].GetComponentInChildren<Text>().text = $"{_abilities[i].Name } costs {_abilities[i].Cost}";
        }
    }

    private bool CanUse(Ability ability)
    {
        if (Resources.Instance.CanUsePower(ability.Cost) == true)
        {
            return true;
        }
        return false;
    }

    public void UseAbility(int index)
    {
        _abilities[index].UseAbility();
    }
}
