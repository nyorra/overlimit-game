using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button toCityButton;
    public Button garageButton;
    public Button settingsButton;
    public Button creditsButton;
    public Button backToMainButton;

    public RectTransform mainMenuRect;
    public RectTransform garageRect;

    void Start()
    {
        toCityButton.onClick.AddListener(LoadCity);
        garageButton.onClick.AddListener(OpenGarage);
        settingsButton.onClick.AddListener(OpenSettigs);
        creditsButton.onClick.AddListener(OpenCredits);
        backToMainButton.onClick.AddListener(BackToMenu);
    }

    void LoadCity()
    {
        Debug.Log("Прогрузка города");
    }

    void OpenGarage()
    {
        mainMenuRect.anchoredPosition = new Vector2(-2000, 0);
        garageRect.anchoredPosition = new Vector2(0, 0);
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

    void BackToMenu()
    {
        mainMenuRect.anchoredPosition = new Vector2(0, 0);
        garageRect.anchoredPosition = new Vector2(2000, 0);
        Debug.Log("Вернулись в меню");
    }
}
