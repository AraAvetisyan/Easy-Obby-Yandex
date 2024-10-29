using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioScript : MonoBehaviour
{
    public static MenuAudioScript instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
