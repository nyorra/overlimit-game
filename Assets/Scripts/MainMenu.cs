using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button ToCityButton;
    public Button GarageButton;
    public Button SettingsButton;
    public Button CreditsButton;

    public RectTransform mainMenuRect;
    public RectTransform garageRect;
    public RectTransform creditsRect;
    public RectTransform settingsRect;

    void Start()
    {
        ToCityButton.onClick.AddListener(LoadCity);
        GarageButton.onClick.AddListener(OpenGarage);
        SettingsButton.onClick.AddListener(OpenSettigs);
        CreditsButton.onClick.AddListener(OpenCredits);
    }

    void LoadCity()
    {
        Debug.Log("Прогрузка города");
    }

    void OpenGarage()
    {
        mainMenuRect.anchoredPosition = new Vector2(2000, 0);
        garageRect.anchoredPosition = new Vector2(0, 0);
        Debug.Log("Перешли в гараж");
    }

    void OpenSettigs()
    {
        mainMenuRect.anchoredPosition = new Vector2(2000, 0);
        settingsRect.anchoredPosition = new Vector2(0, 0);
        
        Debug.Log("Открыли настройки");
    }

    void OpenCredits()
    {
        mainMenuRect.anchoredPosition = new Vector2(2000, 0);
        creditsRect.anchoredPosition = new Vector2(0, 0);
        Debug.Log("Экран авторов");
    }

    public void BackToMenu()
    {
        mainMenuRect.anchoredPosition = new Vector2(0, 0);
        garageRect.anchoredPosition = new Vector2(2000, 0);
        creditsRect.anchoredPosition = new Vector2(2000, 0);
        settingsRect.anchoredPosition = new Vector2(2000, 0);
        Debug.Log("Вернулись в меню");
    }
}
