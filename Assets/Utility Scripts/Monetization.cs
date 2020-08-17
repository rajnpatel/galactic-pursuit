using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Monetization : MonoBehaviour
{
    string GooglePlay_ID = "3758045";
    bool TestMode = false;
    public static bool canDisplayAd = false;

    void Start()
    {
        Advertisement.Initialize(GooglePlay_ID, TestMode);
    }
    void Update()
    {
        if (canDisplayAd)
        {
            Debug.Log(canDisplayAd);
            canDisplayAd = false;
            Advertisement.Show();
        }
    }
    public void DisplayInterstitialAD()
    {
        Advertisement.Show();
    }

}
