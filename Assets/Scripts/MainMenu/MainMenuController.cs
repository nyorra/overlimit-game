using UnityEngine;
using UnityEngine.UI;
using OVERLIMIT.Scenes;
using OVERLIMIT.Logging;

namespace OVERLIMIT.Menu
{
    public class MainMenuController : MonoBehaviour
    {
        [Header("Scene Settings")]
        public SceneType nextScene;

        [Header("Components")]
        [SerializeField] private MainMenuNavigation navigation;
        [SerializeField] private MainMenuLoader loader;

        [Header("Buttons")]
        public Button toCityButton;
        public Button garageButton;
        public Button settingsButton;
        public Button creditsButton;
        public Button[] backButtons; // Список всех кнопок "Назад" на разных панелях

        void Start()
        {
            if (navigation == null || loader == null)
            {
                OverLogger.LogError("Ошибка: В MainMenuController не назначены компоненты Navigation или Loader!", this);
                return;
            }

            // Подписываем кнопки на методы
            toCityButton.onClick.AddListener(OnToCityPressed);
            garageButton.onClick.AddListener(() => navigation.ShowPanel(navigation.garageScreenPanel));
            settingsButton.onClick.AddListener(() => navigation.ShowPanel(navigation.settingsScreenPanel));
            creditsButton.onClick.AddListener(() => navigation.ShowPanel(navigation.creditsScreenPanel));

            foreach (var btn in backButtons)
            {
                btn.onClick.AddListener(navigation.ShowMain);
            }

            OverLogger.LogSuccess("MainMenuController: Все кнопки успешно инициализированы.", this);
        }

        private void OnToCityPressed()
        {
            loader.LoadScene(nextScene);
        }
    }
}
