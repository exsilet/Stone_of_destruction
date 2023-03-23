using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Languages : MonoBehaviour
{
    [SerializeField] private Transform _language;

    private bool isEnabled = false;

    public void ButtonClick()
    {
        isEnabled = isEnabled == false;

        _language.gameObject.SetActive(isEnabled);
    }
}
