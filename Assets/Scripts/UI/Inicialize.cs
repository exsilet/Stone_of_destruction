using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Agava.YandexGames;

public class Inicialize : MonoBehaviour
{
    private const int nameScene = 1;
    private const int textureQualityMobile = 2;
    private const int textureQuality = 8;
    

    private void Start()
    {
        if (Application.isMobilePlatform)
            RenderTexture.active.antiAliasing = textureQualityMobile;
        else
            RenderTexture.active.antiAliasing = textureQuality;
    }

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
