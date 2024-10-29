using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class Analytics : MonoBehaviour
{
    public static Analytics instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
       
    }

    void Start()
    {
      // GameAnalytics.Initialize();
    }

    public void SendEvent(string eventStr)
    {

  //      if (Geekplay.Instance.Platform != Platform.Editor)
    //    {
            try
            {
                //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, eventStr);
                AppMetrica.Instance.ReportEvent(eventStr);
                Debug.Log(eventStr);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
    //}
}