using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LeaderboardElement : MonoBehaviour
{
    [SerializeField] private Image _playerColor;
    [SerializeField] private Image _defaultColor;
    [SerializeField] private Image _currentColor;
    [SerializeField] private TMP_Text _placeText;
    [SerializeField] private Image _langImage;
    [SerializeField] private TMP_Text _nickName;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Image _trophy;

    public void Render(LeaderboardElemetData elemetData)
    {
        
        _placeText.SetText(elemetData.Place.ToString());
        _langImage.sprite = elemetData.Lang;
        _nickName.SetText(elemetData.Name);
        _scoreText.SetText(elemetData.Result.ToString());
    }
}
