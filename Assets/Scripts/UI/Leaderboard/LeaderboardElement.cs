using TMPro;
using UnityEngine;
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

    public void Render(LeaderboardElemetData elementData)
    {
        
        _placeText.SetText(elementData.Place.ToString());
        _langImage.sprite = elementData.Lang;
        _nickName.SetText(elementData.Name);
        _scoreText.SetText(elementData.Result.ToString());
    }
}
