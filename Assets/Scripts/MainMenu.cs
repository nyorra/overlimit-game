using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button toCityButton;
    public Button garageButton;
    public Button settingsButton;
    public Button creditsButton;

    void Start()
    {
        toCityButton.onClick.AddListener(LoadCity);
        garageButton.onClick.AddListener(OpenGarage);
        settingsButton.onClick.AddListener(OpenSettigs);
        creditsButton.onClick.AddListener(OpenCredits);
    }

    void LoadCity()
    {
        Debug.Log("Прогрузка города");
    }

    void OpenGarage()
    {
        Debug.Log("Перешли в гараж");
    }

    void OpenSettigs()
    {
        Debug.Log("Открыли настройки");
    }

    void OpenCredits()
    {
         Debug.Log("Экран авторов");
    }
}