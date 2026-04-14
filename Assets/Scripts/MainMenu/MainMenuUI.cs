using UnityEngine;
using OVERLIMIT.Logging;

namespace OVERLIMIT.Menu
{
    public class MainMenuNavigation : MonoBehaviour
    {
        [Header("Panels")]
        public RectTransform mainScreenPanel;
        public RectTransform garageScreenPanel;
        public RectTransform settingsScreenPanel;
        public RectTransform creditsScreenPanel;

        private readonly Vector2 _hiddenPos = new Vector2(2000, 0);

        public void ShowPanel(RectTransform targetPanel)
        {
            if (targetPanel == null)
            {
                OverLogger.LogWarning("Попытка открыть пустую панель!");
                return;
            }

            // Прячем все панели
            mainScreenPanel.anchoredPosition = _hiddenPos;
            garageScreenPanel.anchoredPosition = _hiddenPos;
            settingsScreenPanel.anchoredPosition = _hiddenPos;
            creditsScreenPanel.anchoredPosition = _hiddenPos;

            // Показываем нужную
            targetPanel.anchoredPosition = Vector2.zero;
            OverLogger.LogSuccess($"Панель {targetPanel.name} открыта.");
        }

        public void ShowMain() => ShowPanel(mainScreenPanel);
    }
}
