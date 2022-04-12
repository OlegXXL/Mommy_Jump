using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdsCore : MonoBehaviour, IUnityAdsListener
{
    private bool _testMode = false;

    private string _gameId = "4686261"; //ваш game id

    private string _video = "Interstitial_Android";
    private string _banner = "Banner_Android";
    private string _rewardedVideo = "Rewarded_Android";

    void Start() // инициализаци€ сервисов
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, _testMode);
    }

    public static void ShowAdsVideo(string placementId) //инициализаци€ рекламы по типу
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(placementId);
        }
        else
        {
            Debug.Log("Advertisement not ready!");
        }

    }
    public void ShowSkipVideo()
    {
        ShowAdsVideo("Interstitial_Android");
    }
    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(_banner);
    }

    public void OnUnityAdsDidError(string message)
    {
        //ошибка рекламы
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // только запустили рекламу
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult) //обработка рекламы (тут определе€ем вознаграждение)
    {
        if (showResult == ShowResult.Finished)
        {
            Debug.Log("+1");
            //действи€, если пользователь посмотрел рекламу до конца
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("„јѕќЋ№");
            //действи€, если пользователь пропустил рекламу + „јѕќЋ№
        }
        else if (showResult == ShowResult.Failed)
        {
            //действи€ при ошибке
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == _rewardedVideo)
        {
            //действи€, если реклама доступна
        }
    }
}