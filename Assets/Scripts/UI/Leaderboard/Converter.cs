using UnityEngine;

public class Converter : MonoBehaviour
{
    [SerializeField] private Sprite _langRu;
    [SerializeField] private Sprite _langEn;
    [SerializeField] private Sprite _langTr;
    [SerializeField] private Sprite _avatarSprite;

    public LeaderboardElemetData ToLeaderboardElementData(int place, string lang, string nick, int playerResult)
    {
        return new LeaderboardElemetData(place, Lang(lang), nick, playerResult);
    }

    private Sprite Lang(string lang)
    {
        return lang switch
        {
            "tr" => _langTr,
            "ru" => _langRu,
            "en" => _langEn,
            _ => _langEn,
        };
    }

    private Sprite DownloadImage(string mediaUrl)
    {
        return _avatarSprite;
    }
}
