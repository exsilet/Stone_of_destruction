using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Converter : MonoBehaviour
{
    [SerializeField] private Sprite _langRu;
    [SerializeField] private Sprite _langEn;
    [SerializeField] private Sprite _langTr;
    [SerializeField] private Sprite _avatarSprite;

    public LeaderboardElemetData ToLeaderboardElemetData(int place, string lang, string nick, int playerResult)
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

        //Texture2D avatarImage;
        //HttpClient client = new HttpClient();

        //HttpResponseMessage response = await client.GetAsync(mediaUrl);
        //UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        //await request.SendWebRequest();
        //if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        //    Debug.Log(request.error);
        //else
        //    avatarImage = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }
}
