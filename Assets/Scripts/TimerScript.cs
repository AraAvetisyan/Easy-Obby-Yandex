using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public float Seconds;
    public float Minutes;

    [SerializeField] private TextMeshProUGUI finalBestTimerText;
    private int stopCounter;
    private float timer = 0f;
    private bool isRunning = true;
    [SerializeField] private TextMeshProUGUI finalText;
    void Start()
    {
        // Загружаем сохраненное время при старте игры
        LoadTime();
    }

    void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime;
            DisplayTime(timer);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = Mathf.FloorToInt((timeToDisplay * 100) % 100);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, (int)milliseconds);
    }

    // Сохранение времени в PlayerPrefs
    public void SaveTime()
    {
        float totalMinutes = Mathf.FloorToInt(timer / 60);
        float totalSeconds = Mathf.FloorToInt(timer % 60);
        float totalMilliseconds = Mathf.FloorToInt((timer * 100) % 100);

        Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] = totalMinutes;
        Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = totalSeconds;
        Geekplay.Instance.PlayerData.CurrentMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = totalMilliseconds;
        Geekplay.Instance.Save();
    }
    public void FinishTime()
    {
        if(Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] == 0 && Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] == 0)
        {
            Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] = Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex];
            Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex];
            Geekplay.Instance.PlayerData.BestMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = Geekplay.Instance.PlayerData.CurrentMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex];
            finalText.text = string.Format("{0:00}:{1:00}:{2:00}", Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex], Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex], (int)Geekplay.Instance.PlayerData.CurrentMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex]);

        }
        if (Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] > Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex])
        {
            Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] = Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex];
            Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex];
            Geekplay.Instance.PlayerData.BestMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = Geekplay.Instance.PlayerData.CurrentMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex];
            finalText.text = string.Format("{0:00}:{1:00}:{2:00}", Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex], Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex], (int)Geekplay.Instance.PlayerData.CurrentMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex]);

        }
        if (Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] == Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex])
        {
            if (Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] > Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex])
            {
                Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] = Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex];
                Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex];
                Geekplay.Instance.PlayerData.BestMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = Geekplay.Instance.PlayerData.CurrentMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex];
                finalText.text = string.Format("{0:00}:{1:00}:{2:00}", Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex], Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex], (int)Geekplay.Instance.PlayerData.CurrentMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex]);

            }
        }
        if (Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] == Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex])
        {
            if (Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] == Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex])
            {
                if (Geekplay.Instance.PlayerData.BestMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex] > Geekplay.Instance.PlayerData.CurrentMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex])
                {
                    Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] = Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex];
                    Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex];
                    Geekplay.Instance.PlayerData.BestMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = Geekplay.Instance.PlayerData.CurrentMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex];

                    finalText.text = string.Format("{0:00}:{1:00}:{2:00}", Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex], Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex], (int)Geekplay.Instance.PlayerData.CurrentMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex]);
                }
            }
        }
        if(Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] > Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex])
        {
            finalText.text = string.Format("{0:00}:{1:00}:{2:00}", Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex], Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex], (int)Geekplay.Instance.PlayerData.BestMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex]);

        }
        Geekplay.Instance.Save();
    }
    // Загрузка времени из PlayerPrefs
    public void LoadTime()
    {
        if (Geekplay.Instance.PlayerData.IsContinue[Geekplay.Instance.PlayerData.MapIndex] == true)
        {
            float savedMinutes = Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex];
            float savedSeconds = Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex];
            float savedMilliseconds = Geekplay.Instance.PlayerData.CurrentMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex];

            // Рассчитываем полное сохраненное время в секундах
            timer = (savedMinutes * 60) + savedSeconds + (savedMilliseconds / 100);
        }
        else
        {
            timer = 0f;  // Если сохранений нет, начинаем с нуля
        }
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
        SaveTime();  // Сохраняем время при остановке таймера
    }
    private void OnApplicationQuit()
    {
        SaveTime();
    }
}