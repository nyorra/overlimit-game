using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button toCityButton;
    public Button garageButton;
    public Button settingsButton;
    public Button creditsButton;

    public RectTransform mainMenuRect;
    public RectTransform garageRect;
    public RectTransform creditsRect;
    public RectTransform settingsRect;

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
