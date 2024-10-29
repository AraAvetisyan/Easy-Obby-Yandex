using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnExit : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        Analytics.instance.SendEvent("ApplicationQuit");
    }
}
