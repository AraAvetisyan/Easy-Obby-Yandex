using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class Utils : MonoBehaviour
{
    //ОБЩИЕ МЕТОДЫ//
    [DllImport("__Internal")]
    public static extern void GamePlatform();
    //ОБЩИЕ МЕТОДЫ//

    //МЕТОДЫ YANDEX//
    [DllImport("__Internal")]
    public static extern void RateGame();

    [DllImport("__Internal")]
    public static extern string GetDomain();

    [DllImport("__Internal")]
    public static extern void SaveExtern(string date);

    [DllImport("__Internal")]
    public static extern void LoadExtern();

    [DllImport("__Internal")]
    public static extern string GetLang();

    [DllImport("__Internal")]
    public static extern void AdInterstitial();

    [DllImport("__Internal")]
    public static extern void AdReward();

    [DllImport("__Internal")]
    public static extern void SetToLeaderboard(int value, string leaderboardName);

    [DllImport("__Internal")]
    public static extern void BuyItem(string idOrTag, string jsonString);

    [DllImport("__Internal")]
    public static extern void CheckBuyItem(string idOrTag);

    [DllImport("__Internal")]
    public static extern void GameReady();
    [DllImport("__Internal")]
    public static extern void GameStop();

    [DllImport("__Internal")]
    public static extern void GameStart();

    [DllImport("__Internal")]
    public static extern void GetLeaderboard(string type, int number, string name);

    //МЕТОДЫ YANDEX//
}
