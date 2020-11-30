using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;


public class AdmobMenuBanner : MonoBehaviour
{
    BannerView bannerView;
    // Use this for initialization
    void Start()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
        // アプリID、 これはテスト用
        //string appId = "ca-app-pub-3940256099942544~3347511713";
        string appId = "ca-app-pub-5584040938629320~9579643178";

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        RequestBanner();
    }

    void OnSceneUnloaded(Scene scene)
    {
        bannerView.OnAdLoaded += (object sender, System.EventArgs args) =>
        {
            bannerView.Destroy();
        };
        bannerView.OnAdFailedToLoad += (object sender, AdFailedToLoadEventArgs args) =>
        {
            bannerView.Destroy();
        };

        bannerView.Destroy();
    }

    private void RequestBanner()
    {

        // 広告ユニットID これはテスト用
        //string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        string adUnitId = "ca-app-pub-5584040938629320/5640398168";

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.TopRight);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder()
            .Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);

        // Create a 320x50 banner at the top of the screen.
        //bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
    }

    // Update is called once per frame
    void Update()
    {

    }
}