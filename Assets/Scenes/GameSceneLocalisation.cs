using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameSceneLocalisation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI level;
    [SerializeField] private TextMeshProUGUI congratulations;
    [SerializeField] private TextMeshProUGUI reward;
    [SerializeField] private TextMeshProUGUI bestTime;
    [SerializeField] private TextMeshProUGUI nextLevel;
    [SerializeField] private TextMeshProUGUI toMenu;
    [SerializeField] private int levelNumber;
    void Start()
    {
        if (Geekplay.Instance.language == "en")
        {
            level.text = "Level " + levelNumber.ToString();
            congratulations.text = "CONGRATULATIONS!";
            reward.text = "REWARD:";
            bestTime.text = "Best Time";
            nextLevel.text = "Next level";
            toMenu.text = "To menu";
        }
        else if (Geekplay.Instance.language == "ru")
        {
            level.text = "Уровень " + levelNumber.ToString();
            congratulations.text = "ПОЗДРАВЛЕНИЯ!";
            reward.text = "ВОЗНАГРАЖДЕНИЕ:";
            bestTime.text = "Лучшее время";
            nextLevel.text = "Следующий уровень";
            toMenu.text = "В меню";
        }
        else if(Geekplay.Instance.language == "tr")
        {
            level.text = "Seviye " + levelNumber.ToString();
            congratulations.text = "TEBRIKLER!";
            reward.text = "ÖDÜL:";
            bestTime.text = "En İyi Zaman";
            nextLevel.text = "Sonraki seviye";
            toMenu.text = "Menüye";
        }
        else if(Geekplay.Instance.language == "es")
        {
            level.text = "Nivel " + levelNumber.ToString();
            congratulations.text = "ENHORABUENA!";
            reward.text = "RECOMPENSA:";
            bestTime.text = "El mejor momento";
            nextLevel.text = "Siguiente nivel";
            toMenu.text = "Al menú";
        }
        else if(Geekplay.Instance.language == "de")
        {
            level.text = "Ebene " + levelNumber.ToString();
            congratulations.text = "HERZLICHEN GLÜCKWUNSCH!";
            reward.text = "REWARD:";
            bestTime.text = "Beste Zeit";
            nextLevel.text = "Nächste Stufe";
            toMenu.text = "Zum Menü";
        }
        else if(Geekplay.Instance.language == "ar")
        {
            level.text = "المستوى " + levelNumber.ToString();
            congratulations.text = "تهانينا!";
            reward.text = "المكافأة:";
            bestTime.text = "أفضل وقت";
            nextLevel.text = "المستوى التالي";
            toMenu.text = "إلى القائمة";
        }
    }

}
