using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class Rewarder : MonoBehaviour
{
    public static Rewarder instance;
    //[SerializeField] string RewardForGold = "GetGold";
    [SerializeField] string AppForDiamond1 = "AppForDiamond1";
    [SerializeField] string AppForDiamond2 = "AppForDiamond2";
    [SerializeField] string AppForDiamond3 = "AppForDiamond3";
    [SerializeField] string AppForDiamond4 = "AppForDiamond4";
    [SerializeField] string AppForDiamond5 = "AppForDiamond5";
   // public int RewardForGoldGold = 50;
    public int PurchaseForDiamond_Diamond1 = 100;
    public int PurchaseForDiamond_Diamond2 = 200;
    public int PurchaseForDiamond_Diamond3 = 500;
    public int PurchaseForDiamond_Diamond4 = 1000;
    public int PurchaseForDiamond_Diamond5 = 2000;
   // public Action RewardShowed;
    Dictionary<string, int> OperationNameAndReward = new();
    public static Action<bool> ChangeDiamond;
    private void Awake()
    {
      //  OperationNameAndReward.Add(RewardForGold, RewardForGoldGold);
        OperationNameAndReward.Add(AppForDiamond1, PurchaseForDiamond_Diamond1);
        OperationNameAndReward.Add(AppForDiamond2, PurchaseForDiamond_Diamond2);
        OperationNameAndReward.Add(AppForDiamond3, PurchaseForDiamond_Diamond3);
        OperationNameAndReward.Add(AppForDiamond4, PurchaseForDiamond_Diamond4);
        OperationNameAndReward.Add(AppForDiamond5, PurchaseForDiamond_Diamond5);
        instance = this;
    }
    void Start()
    {
       // Geekplay.Instance.SubscribeOnReward(RewardForGold, GetGoldReward);
        Geekplay.Instance.SubscribeOnPurchase(AppForDiamond1, GetDiamondPur1);
        Geekplay.Instance.SubscribeOnPurchase(AppForDiamond2, GetDiamondPur2);
        Geekplay.Instance.SubscribeOnPurchase(AppForDiamond3, GetDiamondPur3);
        Geekplay.Instance.SubscribeOnPurchase(AppForDiamond4, GetDiamondPur4);
        Geekplay.Instance.SubscribeOnPurchase(AppForDiamond5, GetDiamondPur5);
    }
    public int GetDiamondCountByName(string Name)
    {
        try
        {
            return OperationNameAndReward[Name];
        }
        catch
        {
            Debug.Log("Õ≈¬≈–ÕŒ≈ »Ãﬂ ƒÀﬂ PURCHASE");
            return -1;
        }
    }

    //private void GetGoldReward()
    //{
    //    Geekplay.Instance.PlayerData.Coins += RewardForGoldGold;
    //    RewardShowed?.Invoke();
    //}
    private void GetDiamondPur1()
    {
        Geekplay.Instance.PlayerData.Diamond += PurchaseForDiamond_Diamond1;
        ChangeDiamond?.Invoke(true);
       // Geekplay.Instance.PlayerData.DonatCount += PurchaseForGoldGold1;
       //  Geekplay.Instance.Leaderboard("Donat", Geekplay.Instance.PlayerData.DonatCount);
        Geekplay.Instance.Save();
    }
    private void GetDiamondPur2()
    {
        Geekplay.Instance.PlayerData.Diamond += PurchaseForDiamond_Diamond2;
        ChangeDiamond?.Invoke(true);
        //  Geekplay.Instance.PlayerData.DonatCount += PurchaseForGoldGold2;
        //  Geekplay.Instance.Leaderboard("Donat", Geekplay.Instance.PlayerData.DonatCount);
        Geekplay.Instance.Save();
    }
    private void GetDiamondPur3()
    {
        Geekplay.Instance.PlayerData.Diamond += PurchaseForDiamond_Diamond3;
        ChangeDiamond?.Invoke(true);
        //    Geekplay.Instance.PlayerData.DonatCount += PurchaseForGoldGold3;
        //   Geekplay.Instance.Leaderboard("Donat", Geekplay.Instance.PlayerData.DonatCount);
        Geekplay.Instance.Save();
    }
    private void GetDiamondPur4()
    {
        Geekplay.Instance.PlayerData.Diamond += PurchaseForDiamond_Diamond4;
        ChangeDiamond?.Invoke(true);
        // Geekplay.Instance.PlayerData.DonatCount += PurchaseForGoldGold4;
        //  Geekplay.Instance.Leaderboard("Donat", Geekplay.Instance.PlayerData.DonatCount);
        Geekplay.Instance.Save();
    }
    private void GetDiamondPur5()
    {
        Geekplay.Instance.PlayerData.Diamond += PurchaseForDiamond_Diamond5;
        ChangeDiamond?.Invoke(true);
        //  Geekplay.Instance.PlayerData.DonatCount += PurchaseForGoldGold5;
        //  Geekplay.Instance.Leaderboard("Donat", Geekplay.Instance.PlayerData.DonatCount);
        Geekplay.Instance.Save();
    }
}