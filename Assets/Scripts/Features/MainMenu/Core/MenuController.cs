using OVERLIMIT.Core;
using OVERLIMIT.Core.Messages.MainMenu;
using OVERLIMIT.Utility.Logging;
using OVERLIMIT.Utility.Validation;
using UnityEngine;
using UnityEngine.UI;

namespace OVERLIMIT.Menu
{
    /// <summary>
    /// Core brain of the main menu system. Bridges on-screen button interactions
    /// with core application actions, such as panel toggling or dispatching the city level load.
    /// </summary>
    public class MenuController : MonoBehaviour
    {
        [Header("Scene Settings")]
        public SceneType cityScene; // The destination gameplay level (typically City).

        [Header("References")]
        [SerializeField]
        private MenuNavigation navigation; // System responsible for UI panel management and state transitions.

        [SerializeField]
        private MenuLoader loader; // Gateway system for loading and bootstrapping game scenes.

        [Header("Interaction Elements")]
        public Button toCityButton; // "Play" action trigger.
        public Button garageButton; // "Garage" view trigger.
        public Button settingsButton; // "Settings" view trigger.
        public Button creditsButton; // "Credits" view trigger.
        public Button[] backButtons; // Collective collection of return buttons from all sub-panels.

        private void Start()
        {
            // Validates the MainMenu infrastructure, checking controllers, button elements, and navigation sub-panels.
            if (
                this.BeginValidation()
                    .Require(navigation, nameof(navigation))
                    .Require(loader, nameof(loader))
                    .Require(toCityButton, nameof(toCityButton))
                    .Require(garageButton, nameof(garageButton))
                    .Require(settingsButton, nameof(settingsButton))
                    .Require(creditsButton, nameof(creditsButton))
                    .RequireList(backButtons, nameof(backButtons))
                    // Nested dependency hierarchy validation
                    .Require(
                        navigation?.mainScreenPanel,
                        $"{nameof(navigation)}.{nameof(navigation.mainScreenPanel)}"
                    )
                    .Require(
                        navigation?.garageScreenPanel,
                        $"{nameof(navigation)}.{nameof(navigation.garageScreenPanel)}"
                    )
                    .Require(
                        navigation?.settingsScreenPanel,
                        $"{nameof(navigation)}.{nameof(navigation.settingsScreenPanel)}"
                    )
                    .Require(
                        navigation?.creditsScreenPanel,
                        $"{nameof(navigation)}.{nameof(navigation.creditsScreenPanel)}"
                    )
                    .LogAndCheck()
            )
                return;

            // Bind core menu button events
            toCityButton.onClick.AddListener(() => loader.LoadScene(cityScene));
            garageButton.onClick.AddListener(() =>
                navigation.ShowPanel(navigation.garageScreenPanel)
            );
            settingsButton.onClick.AddListener(() =>
                navigation.ShowPanel(navigation.settingsScreenPanel)
            );
            creditsButton.onClick.AddListener(() =>
                navigation.ShowPanel(navigation.creditsScreenPanel)
            );

            // Dynamically assign fallback routing to all generic return controls
            foreach (var btn in backButtons)
            {
                btn.onClick.AddListener(navigation.ShowMain);
            }

            OverLogger.LogSuccess(SelfMainMenuMsg.MenuReady, this);
        }
    }
}
