using System.Collections.Generic;
using OVERLIMIT.Core.Messages.MainMenu;
using OVERLIMIT.Utility.Logging;
using UnityEngine;

namespace OVERLIMIT.Menu
{
    /// <summary>
    /// Manages window routing and visibility transitions within the main menu system
    /// (e.g., Main Screen, Garage, Settings, and Credits).
    /// </summary>
    public class MenuNavigation : MonoBehaviour
    {
        [Header("UI Panels")]
        public RectTransform mainScreenPanel;
        public RectTransform garageScreenPanel;
        public RectTransform settingsScreenPanel;
        public RectTransform creditsScreenPanel;

        // Internal collection used for collective batch operations on all menu panels.
        private List<RectTransform> _allPanels;

        private void Awake()
        {
            OverLogger.ClearConsole();

            // Consolidates all screen references into a unified collection
            _allPanels = new List<RectTransform>
            {
                mainScreenPanel,
                garageScreenPanel,
                settingsScreenPanel,
                creditsScreenPanel,
            };
        }

        /// Activates the specified UI panel while programmatically filtering and hiding all others.
        public void ShowPanel(RectTransform targetPanel)
        {
            // Iterates through the entire registry: activates the matching panel and disables the rest
            foreach (var panel in _allPanels)
            {
                if (panel != null)
                {
                    panel.gameObject.SetActive(panel == targetPanel);
                }
            }

            OverLogger.LogSuccess(SelfMainMenuMsg.PanelOpened(targetPanel.name), this);
        }

        /// Convenience shortcut to immediately restore the menu system to its baseline main screen state.
        public void ShowMain() => ShowPanel(mainScreenPanel);
    }
}
