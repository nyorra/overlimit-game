using System.Collections.Generic;
using OVERLIMIT.Core.Messages.MainMenu;
using OVERLIMIT.Utility.Logging;
using UnityEngine;

namespace OVERLIMIT.Menu
{
    /// <summary>
    /// Управляет переключением окон в главном меню (Главная, Гараж, Настройки, Авторы).
    /// </summary>
    public class MenuNavigation : MonoBehaviour
    {
        [Header("Panels")]
        public RectTransform mainScreenPanel;
        public RectTransform garageScreenPanel;
        public RectTransform settingsScreenPanel;
        public RectTransform creditsScreenPanel;

        // Список для удобного перебора всех панелей разом
        private List<RectTransform> _allPanels;

        void Awake()
        {
            OverLogger.ClearConsole();
            // Складываем все панели едино
            _allPanels = new List<RectTransform>
            {
                mainScreenPanel,
                garageScreenPanel,
                settingsScreenPanel,
                creditsScreenPanel,
            };
        }

        public void ShowPanel(RectTransform targetPanel)
        {
            // Проходим по всем панелям: нужную включаем, остальные — выключаем
            foreach (var panel in _allPanels)
            {
                if (panel != null)
                {
                    panel.gameObject.SetActive(panel == targetPanel);
                }
            }

            OverLogger.LogSuccess(SelfMainMenuMsg.PanelOpened(targetPanel.name), this);
        }

        // Быстрый метод для возврата на главный экран
        public void ShowMain() => ShowPanel(mainScreenPanel);
    }
}
