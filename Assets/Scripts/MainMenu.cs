using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using OVERLIMIT.Logging;

public class MainMenu : MonoBehaviour
{
    [Header("Buttons")]
    public Button ToCityButton;
    public Button GarageButton;
    public Button SettingsButton;
    public Button CreditsButton;

    [Header("Panels")]
    public RectTransform MainScreenPanel;
    public RectTransform GarageScreenPanel;
    public RectTransform CreditsScreenPanel;
    public RectTransform SettingsScreenPanel;


    void Start()
    {
        // Проверяем ссылки
        Object[] MainMenuElements = {
            ToCityButton, GarageButton, SettingsButton, CreditsButton,
            MainScreenPanel, GarageScreenPanel, CreditsScreenPanel, SettingsScreenPanel
        };

        foreach (var reference in MainMenuElements)
        {
            if (reference == null)
            {
                // Если хоть одна ссылка пуста — лог покажет, на каком объекте проблема
                OverLogger.LogError("Missing UI reference in MainMenu! Check the Inspector.", this);
                return;
            }
        }

        ToCityButton.onClick.AddListener(LoadCity);
        GarageButton.onClick.AddListener(OpenGarage);
        SettingsButton.onClick.AddListener(OpenSettings);
        CreditsButton.onClick.AddListener(OpenCredits);

        OverLogger.LogSuccess("MainMenu initialized and listeners attached.", this);
    }

    void LoadCity()
    {
        OverLogger.LogSuccess("City loading initiated...");
        SceneManager.LoadScene("City");
    }

    void OpenGarage() => SwitchPanel(GarageScreenPanel, "Garage");
    void OpenSettings() => SwitchPanel(SettingsScreenPanel, "Settings");
    void OpenCredits() => SwitchPanel(CreditsScreenPanel, "Credits");

    public void BackToMenu()
    {
        // Просто переключаемся обратно на главное меню
        SwitchPanel(MainScreenPanel, "Main Menu");

        // Сбрасываем остальные панели в сторону
        GarageScreenPanel.anchoredPosition = new Vector2(2000, 0);
        CreditsScreenPanel.anchoredPosition = new Vector2(2000, 0);
        SettingsScreenPanel.anchoredPosition = new Vector2(2000, 0);
    }

    private void SwitchPanel(RectTransform targetPanel, string panelName)
    {
        // тк метод можно вызват
        if (targetPanel == null)
        {
            OverLogger.LogWarning($"UI: Attempted to open a null panel: {panelName}!");
            return;
        }

        // Сначала "прячем" всё за экран (универсальный подход)
        MainScreenPanel.anchoredPosition = new Vector2(2000, 0);

        // Выводим нужную панель в центр
        targetPanel.anchoredPosition = Vector2.zero;

        OverLogger.LogSuccess($"UI: {panelName} panel opened.");
    }
}
