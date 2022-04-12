using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdsCore : MonoBehaviour, IUnityAdsListener
{
    private bool _testMode = false;

    private string _gameId = "4686261"; //��� game id

    private string _video = "Interstitial_Android";
    private string _banner = "Banner_Android";
    private string _rewardedVideo = "Rewarded_Android";

    void Start() // ������������� ��������
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, _testMode);
    }

    public static void ShowAdsVideo(string placementId) //������������� ������� �� ����
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
        //������ �������
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // ������ ��������� �������
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult) //��������� ������� (��� ����������� ��������������)
    {
        if (showResult == ShowResult.Finished)
        {
            Debug.Log("+1");
            //��������, ���� ������������ ��������� ������� �� �����
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("������");
            //��������, ���� ������������ ��������� ������� + ������
        }
        else if (showResult == ShowResult.Failed)
        {
            //�������� ��� ������
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == _rewardedVideo)
        {
            //��������, ���� ������� ��������
        }
    }
}