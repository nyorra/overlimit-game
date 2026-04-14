using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using OVERLIMIT.Logging;
using System.Collections;
using OVERLIMIT.Scenes;
using OVERLIMIT.Garage;

public class MainMenu : MonoBehaviour
{
    [Header("Next Scene")]
    public SceneType nextScene;

    [Header("Buttons")]
    public Button ToCityButton;
    public Button GarageButton;
    public Button SettingsButton;
    public Button CreditsButton;

    [Header("Panels")]
    public RectTransform MainScreenPanel;
    public RectTransform GarageScreenPanel;
    public RectTransform SettingsScreenPanel;
    public RectTransform CreditsScreenPanel;

    void Start()
    {
        // Проверка ссылок на элементы UI
        Object[] MainMenuElements = {
            ToCityButton, GarageButton, SettingsButton, CreditsButton,
            MainScreenPanel, GarageScreenPanel, CreditsScreenPanel, SettingsScreenPanel
        };

        foreach (var reference in MainMenuElements)
        {
            if (reference == null)
            {
                OverLogger.LogError($"Ошибка: В инспекторе MainMenu не назначены ссылки на {reference} UI!", this);
                return;
            }
        }

        ToCityButton.onClick.AddListener(LoadCity);
        GarageButton.onClick.AddListener(OpenGarage);
        SettingsButton.onClick.AddListener(OpenSettings);
        CreditsButton.onClick.AddListener(OpenCredits);

        OverLogger.LogSuccess("MainMenu: Все кнопки и панели успешно инициализированы.", this);
    }

    void LoadCity()
    {
        StartCoroutine(LoadCityRoutine());
        // Логируем только факт запуска процесса
        OverLogger.LogSuccess($"Запущен процесс асинхронной загрузки сцены: {nextScene}", this);
    }

    IEnumerator LoadCityRoutine()
    {
        string sceneName = nextScene.ToString();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        if (asyncLoad == null)
        {
            OverLogger.LogError($"Критическая ошибка: Не удалось начать загрузку сцены {sceneName}!");
            yield break;
        }

        // while (!asyncLoad.isDone)
        // {
        //     yield return null;
        // }

        OverLogger.LogSuccess($"Сцена [{sceneName}] успешно загружена. Объект [{CarModels.SelectedCarName}] готов к спавну.", this);

        // SpawnPlayerCar();
    }



    void OpenGarage() => SwitchPanel(GarageScreenPanel, "Garage");
    void OpenSettings() => SwitchPanel(SettingsScreenPanel, "Settings");
    void OpenCredits() => SwitchPanel(CreditsScreenPanel, "Credits");

    public void BackToMenu()
    {
        SwitchPanel(MainScreenPanel, "Main Menu");

        GarageScreenPanel.anchoredPosition = new Vector2(2000, 0);
        CreditsScreenPanel.anchoredPosition = new Vector2(2000, 0);
        SettingsScreenPanel.anchoredPosition = new Vector2(2000, 0);

        OverLogger.LogSuccess("Возврат в главное меню выполнен.", this);
    }

    private void SwitchPanel(RectTransform targetPanel, string panelName)
    {
        if (targetPanel == null)
        {
            OverLogger.LogWarning($"Предупреждение: Попытка открыть отсутствующую панель [{panelName}]!");
            return;
        }

        MainScreenPanel.anchoredPosition = new Vector2(2000, 0);
        targetPanel.anchoredPosition = Vector2.zero;

        OverLogger.LogSuccess($"Панель [{panelName}] успешно открыта.");
    }
}
