using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainMenuUI : MonoBehaviour
{
    public bool NewGame;
    public bool ContinueGame;
    public static MainMenuUI Instance;
    [SerializeField] private GameObject  shopPanel;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI diamondsText;
    public bool Continue;
    [SerializeField] private GameObject runMenu, bicycleMenu, carMenu;
    [SerializeField] private GameObject runPanel, bicyclePanel, carPanel;
    [SerializeField] private TextMeshProUGUI[] timerLevels;
    //[SerializeField] private Image[] progressLevels;
    [SerializeField] private UnityEngine.UI.Slider[] progressLevels;
    [SerializeField] private GameObject[] progressLevelsObjects;
    [SerializeField] private TextMeshProUGUI[] progressPercentLevels;
    [SerializeField] private AudioSource uiAudio;
    [SerializeField] private TextMeshProUGUI runPercent, bicyclePercet, carPercent;
    private int runPercentCount, bicyclePercentCount, carPercentCount;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Geekplay.Instance.GameStart();
        Geekplay.Instance.GameStop();
        Geekplay.Instance.ShowInterstitialAd();
        coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();
        diamondsText.text = Geekplay.Instance.PlayerData.Diamond.ToString();
        StartCoroutine(WaitFrame());
    }
    public IEnumerator WaitFrame()
    {
        yield return new WaitForFixedUpdate();

        if (Geekplay.Instance.PlayerData.SaveProgressLevels == null)
        {
            Geekplay.Instance.PlayerData.SaveProgressLevels = new int[15];
        }
        if (Geekplay.Instance.PlayerData.SaveProgressMenuLevels == null)
        {
            Geekplay.Instance.PlayerData.SaveProgressMenuLevels = new int[15];
        }
        if (Geekplay.Instance.PlayerData.FillAmountLevels == null)
        {
            Geekplay.Instance.PlayerData.FillAmountLevels = new float[15];
        }
        if (Geekplay.Instance.PlayerData.BestMapMinutesLevels == null)
        {
            Geekplay.Instance.PlayerData.BestMapMinutesLevels = new float[15];
        }
        if (Geekplay.Instance.PlayerData.BestMapSecondsLevels == null)
        {
            Geekplay.Instance.PlayerData.BestMapSecondsLevels = new float[15];
        }
        if (Geekplay.Instance.PlayerData.BestMapMilisecondsLevels == null)
        {
            Geekplay.Instance.PlayerData.BestMapMilisecondsLevels = new float[15];
        }
        if (Geekplay.Instance.PlayerData.CurrentMapMinutesLevels == null)
        {
            Geekplay.Instance.PlayerData.CurrentMapMinutesLevels = new float[15];
        }
        if (Geekplay.Instance.PlayerData.CurrentMapSecondsLevels == null)
        {
            Geekplay.Instance.PlayerData.CurrentMapSecondsLevels = new float[15];
        }
        if (Geekplay.Instance.PlayerData.CurrentMapMilisecondsLevels == null)
        {
            Geekplay.Instance.PlayerData.CurrentMapMilisecondsLevels = new float[15];
        }
        if (Geekplay.Instance.PlayerData.Rotation == null)
        {
            Geekplay.Instance.PlayerData.Rotation = new int[15];
        }
        if (Geekplay.Instance.PlayerData.IsContinue == null)
        {
            Geekplay.Instance.PlayerData.IsContinue = new bool[15];
        }
        for (int i = 0;i< progressLevels.Length; i++)
        {
            if (Geekplay.Instance.PlayerData.SaveProgressLevels[i] == 0)
            {
                progressLevelsObjects[i].gameObject.SetActive(false);
            }
        }
        Geekplay.Instance.Save();
        for (int i = 0; i< Geekplay.Instance.PlayerData.SaveProgressMenuLevels.Length; i++)
        {
            if (i >= 0 && i < 5) {
                runPercentCount += Geekplay.Instance.PlayerData.SaveProgressMenuLevels[i];
            }
            if(i >= 5 && i < 10)
            {
                bicyclePercentCount += Geekplay.Instance.PlayerData.SaveProgressMenuLevels[i];
            }
            if( i >= 10 && i < 15)
            {
                carPercentCount += Geekplay.Instance.PlayerData.SaveProgressMenuLevels[i];
            }
        }
        runPercent.text = runPercentCount.ToString() + "/200%";
        bicyclePercet.text = bicyclePercentCount.ToString() + "/200%";
        carPercent.text = carPercentCount.ToString() + "/200%";
    }
    private void OnEnable()
    {
        Rewarder.ChangeDiamond += ChangeDimondsText;
    }
    private void OnDisable()
    {
        Rewarder.ChangeDiamond -= ChangeDimondsText;

    }
    public void ChangeDimondsText(bool bb)
    {
        diamondsText.text = Geekplay.Instance.PlayerData.Diamond.ToString();
    }
    public void PressedMenu(GameObject panel)
    {
        uiAudio.Play();
        panel.SetActive(true);

        for (int i = 0; i < Geekplay.Instance.PlayerData.FillAmountLevels.Length; i++)
        {
            if (Geekplay.Instance.PlayerData.SaveProgressMenuLevels[i] >= 100)
            {
                Geekplay.Instance.PlayerData.SaveProgressMenuLevels[i] = 100;
            }
            progressLevels[i].value = Geekplay.Instance.PlayerData.FillAmountLevels[i];
            progressPercentLevels[i].text = Geekplay.Instance.PlayerData.SaveProgressMenuLevels[i].ToString() + "%";
        }      

        var culture = new CultureInfo("en-EN");

        for (int i = 0; i < Geekplay.Instance.PlayerData.BestMapMinutesLevels.Length; i++)
        {
            if (Geekplay.Instance.PlayerData.BestMapMinutesLevels[i] < 10)
            {
                if (Geekplay.Instance.PlayerData.BestMapSecondsLevels[i] < 10)
                {
                    timerLevels[i].text = "0" + Geekplay.Instance.PlayerData.BestMapMinutesLevels[i].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestMapSecondsLevels[i].ToString("F2", culture);
                }
                else
                {
                    timerLevels[i].text = "0" + Geekplay.Instance.PlayerData.BestMapMinutesLevels[i].ToString() + "." + Geekplay.Instance.PlayerData.BestMapSecondsLevels[i].ToString("F2", culture);
                }
            }
            if (Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] >= 10)
            {
                if (Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] < 10)
                {
                    timerLevels[i].text = Geekplay.Instance.PlayerData.BestMapMinutesLevels[i].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestMapSecondsLevels[i].ToString("F2", culture);
                }
                else
                {
                    timerLevels[i].text = Geekplay.Instance.PlayerData.BestMapMinutesLevels[i].ToString() + "." + Geekplay.Instance.PlayerData.BestMapSecondsLevels[i].ToString("F2", culture);
                }
            }
        }
    }

    public void PressedShopMenu()
    {
        uiAudio.Play();
        shopPanel.SetActive(true);
    }
    public void PressedBack()
    {
        uiAudio.Play();
        runMenu.SetActive(false);
        bicycleMenu.SetActive(false);
        carMenu.SetActive(false);
        shopPanel.SetActive(false);
        runPanel.SetActive(false);
        bicyclePanel.SetActive(false);
        carPanel.SetActive(false);
    }

    public void PressedContinue()
    {
        uiAudio.Play();
        Continue = true;
        Geekplay.Instance.PlayerData.IsContinue[Geekplay.Instance.PlayerData.MapIndex] = true;

        if (Geekplay.Instance.PlayerData.SaveProgressMenuLevels[Geekplay.Instance.PlayerData.MapIndex] >= 100)
        {
            Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
            Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
            Geekplay.Instance.PlayerData.CurrentMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
            Geekplay.Instance.PlayerData.SaveProgressMenuLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
            Geekplay.Instance.PlayerData.FillAmountLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
            Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
            Geekplay.Instance.PlayerData.Rotation[Geekplay.Instance.PlayerData.MapIndex] = 0;
        }
        ContinueGame = true;
        StartCoroutine(LoadScene());
      //  SceneManager.LoadScene(Geekplay.Instance.PlayerData.MapIndex + 1);
    }
    public void PressedNewGame()
    {
        uiAudio.Play();
        Continue = false;
        Geekplay.Instance.PlayerData.IsContinue[Geekplay.Instance.PlayerData.MapIndex] = false;
        Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
        Geekplay.Instance.PlayerData.CurrentMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
        Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
        Geekplay.Instance.PlayerData.SaveProgressMenuLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
        Geekplay.Instance.PlayerData.FillAmountLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
        Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
        Geekplay.Instance.PlayerData.Rotation[Geekplay.Instance.PlayerData.MapIndex] = 0;
        Geekplay.Instance.Save();
        NewGame = true;
        StartCoroutine(LoadScene());

    }
    public void GameMenu(int LevelIndex)
    {
        uiAudio.Play();
        Geekplay.Instance.PlayerData.MapIndex = LevelIndex;
        Geekplay.Instance.Save();
        if(LevelIndex>=0 && LevelIndex <= 4)
        {
            runMenu.SetActive(true);
        }
        else if(LevelIndex >= 5 && LevelIndex <= 9)
        {
            bicycleMenu.SetActive(true);
        }
        else
        {
            carMenu.SetActive(true);
        }
        
    }
    public IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.2f); 
        SceneManager.LoadScene(Geekplay.Instance.PlayerData.MapIndex + 1);
    }
}
