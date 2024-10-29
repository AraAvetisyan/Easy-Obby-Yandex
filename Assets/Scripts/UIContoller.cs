using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIContoller : MonoBehaviour
{
    [SerializeField] private bool isRunningMode, isBicycleMode, isCarMode;
    [SerializeField] private TimerScript _timerScript;
    [SerializeField] private AudioSource uiAudio;
    private bool isHome;
    private void Start()
    {

        Geekplay.Instance.GameReady();
    }
    public void PressedHome()
    {
        _timerScript.SaveTime();
        Analytics.instance.SendEvent(SceneManager.GetActiveScene().name + "ExitLevel");
        Geekplay.Instance.Save();
        uiAudio.Play();
        isHome = true;
        Geekplay.Instance.ShowInterstitialAd();
        StartCoroutine(LoadScene());
        //  SceneManager.LoadScene("MainMenu");
    }
    public void PressedHomeFinal()
    {
        uiAudio.Play();
        isHome = true;
        Geekplay.Instance.ShowInterstitialAd();
        StartCoroutine(LoadScene());
        //   SceneManager.LoadScene("MainMenu"); 
    }
    public void PressedNext()
    {
        if (Geekplay.Instance.PlayerData.SaveProgressMenuLevels[Geekplay.Instance.PlayerData.MapIndex+1] >= 100)
        {
            Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex + 1] = 0;
            Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex + 1] = 0;
            Geekplay.Instance.PlayerData.CurrentMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex + 1] = 0;
            Geekplay.Instance.PlayerData.SaveProgressMenuLevels[Geekplay.Instance.PlayerData.MapIndex + 1] = 0;
            Geekplay.Instance.PlayerData.FillAmountLevels[Geekplay.Instance.PlayerData.MapIndex + 1] = 0;
            Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex + 1] = 0;
            Geekplay.Instance.PlayerData.Rotation[Geekplay.Instance.PlayerData.MapIndex + 1] = 0;
        }
        Geekplay.Instance.PlayerData.MapIndex += 1;

        Geekplay.Instance.Save();
        uiAudio.Play();
        Geekplay.Instance.ShowInterstitialAd();
        StartCoroutine(LoadScene());
        // SceneManager.LoadScene(Geekplay.Instance.PlayerData.MapIndex + 1);


    }

    public IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.3f);
        if (!isHome)
        {
            SceneManager.LoadScene(Geekplay.Instance.PlayerData.MapIndex + 1);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
