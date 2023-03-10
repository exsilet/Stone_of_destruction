using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Agava.YandexGames;

public class Inicialize : MonoBehaviour
{
    private const int nameScene = 1;

    private void Awake()
    {
        StartCoroutine(Init());
    }

    private IEnumerator Init()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield return new WaitForSeconds(0.1f);
#elif YANDEX_GAMES
        while(YandexGamesSdk.IsInitialized == false)
        {
            yield return YandexGamesSdk.Initialize();
        }

        YandexGamesSdk.CallbackLogging = true;
#endif

        //GameAnalytics.Initialize();
        SceneManager.LoadScene(nameScene);
    }
}
