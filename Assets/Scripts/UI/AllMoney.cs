using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AllMoney : MonoBehaviour
{
    [SerializeField] private TMP_Text _AllMoney;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {

    }

    private void OnMoneyChanged(int money)
    {
        _AllMoney.text = money.ToString();
    }
}
