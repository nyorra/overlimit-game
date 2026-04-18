using UnityEngine;
using UnityEngine.UI;
using OVERLIMIT.Scenes;
using OVERLIMIT.Logging;
using OVERLIMIT.Validate;
using OVERLIMIT.Messages;
using System;


namespace OVERLIMIT.Menu
{
    /// <summary>
    /// Главный мозг меню. Связывает кнопки на экране с действиями
    /// переключение окон или запуск загрузки города.
    /// </summary>
    public class MenuController : MonoBehaviour
    {
        [Header("Scene Settings")]
        public SceneType cityScene; // Сцена, куда поедем (обычно City)

        [Header("References")]
        [SerializeField] private MenuNavigation navigation; // Скрипт переключения панелей
        [SerializeField] private MenuLoader loader;         // Скрипт загрузки сцен

        [Header("Buttons")]
        public Button toCityButton;    // Кнопка "Играть"
        public Button garageButton;    // Кнопка "Гараж"
        public Button settingsButton;  // Кнопка "Настройки"
        public Button creditsButton;   // Кнопка "Авторы"
        public Button[] backButtons;   // Все кнопки "Назад" со всех панелей разом

        void Start()
        {
            // Валидируем модуль MainMenu: контроллеры, кнопки и панели навигации
            if (this.BeginValidation()
                    .Require(navigation, nameof(navigation))
                    .Require(loader, nameof(loader))
                    .Require(toCityButton, nameof(toCityButton))
                    .Require(garageButton, nameof(garageButton))
                    .Require(settingsButton, nameof(settingsButton))
                    .Require(creditsButton, nameof(creditsButton))
                    .RequireList(backButtons, nameof(backButtons))
                    // Проверяем панели
                    .Require(navigation?.mainScreenPanel, $"{nameof(navigation)}.{nameof(navigation.mainScreenPanel)}")
                    .Require(navigation?.garageScreenPanel, $"{nameof(navigation)}.{nameof(navigation.garageScreenPanel)}")
                    .Require(navigation?.settingsScreenPanel, $"{nameof(navigation)}.{nameof(navigation.settingsScreenPanel)}")
                    .Require(navigation?.creditsScreenPanel, $"{nameof(navigation)}.{nameof(navigation.creditsScreenPanel)}")
                    .LogAndCheck())
                return;

            // Основные кнопки
            toCityButton.onClick.AddListener(() => loader.LoadScene(cityScene));
            garageButton.onClick.AddListener(() => navigation.ShowPanel(navigation.garageScreenPanel));
            settingsButton.onClick.AddListener(() => navigation.ShowPanel(navigation.settingsScreenPanel));
            creditsButton.onClick.AddListener(() => navigation.ShowPanel(navigation.creditsScreenPanel));


            // Кнопки "Назад"
            foreach (var btn in backButtons)
            {
                btn.onClick.AddListener(navigation.ShowMain);
            }

            OverLogger.LogSuccess(AppMessages.MainMenu.MenuReady, this);
        }
    }
}
