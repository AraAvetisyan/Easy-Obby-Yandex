using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{

    /////InApps//////
    public string lastBuy;

    public int Coins;
    public int Diamond;

    public int MapIndex;

    public int[] SaveProgressLevels;
    public int[] SaveProgressMenuLevels;
    public float[] FillAmountLevels;
    public float[] BestMapMinutesLevels;
    public float[] BestMapSecondsLevels;
    public float[] BestMapMilisecondsLevels;
    public float[] CurrentMapMinutesLevels;
    public float[] CurrentMapSecondsLevels;
    public float[] CurrentMapMilisecondsLevels;
    public int[] Rotation; // 0 - Front, 1 - Back, 2 - Right, 3 - Left
    public bool[] IsContinue;
}