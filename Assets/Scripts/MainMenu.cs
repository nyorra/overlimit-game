using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using OVERLIMIT.Logging;
using OVERLIMIT.Scenes;
using OVERLIMIT.Loading;

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

    public SceneType nextScene = SceneType.City; 

    void Start()
    {
        ToCityButton.onClick.AddListener(LoadCity);
        GarageButton.onClick.AddListener(OpenGarage);
        SettingsButton.onClick.AddListener(OpenSettigs);
        CreditsButton.onClick.AddListener(OpenCredits);
        OverLogger.LogSuccess("MainMenu start прогружен");        
    }

    

    void LoadCity()
    {
        SceneManager.LoadScene("City"); 
        OverLogger.LogSuccess("Запуск загрузки города");
    }


    void OpenGarage()
    {
        mainMenuRect.anchoredPosition = new Vector2(2000, 0);
        garageRect.anchoredPosition = new Vector2(0, 0);
        OverLogger.LogSuccess("Перешли в гараж");
    }

    void OpenSettigs()
    {
        mainMenuRect.anchoredPosition = new Vector2(2000, 0);
        settingsRect.anchoredPosition = new Vector2(0, 0);
        
        OverLogger.LogSuccess("Открыли настройки");
    }

    void OpenCredits()
    {
        mainMenuRect.anchoredPosition = new Vector2(2000, 0);
        creditsRect.anchoredPosition = new Vector2(0, 0);
        OverLogger.LogSuccess("Экран авторов");
    }

    public void BackToMenu()
    {
        mainMenuRect.anchoredPosition = new Vector2(0, 0);
        garageRect.anchoredPosition = new Vector2(2000, 0);
        creditsRect.anchoredPosition = new Vector2(2000, 0);
        settingsRect.anchoredPosition = new Vector2(2000, 0);   
        OverLogger.LogSuccess("Вернулись в гараж");
    }
}
