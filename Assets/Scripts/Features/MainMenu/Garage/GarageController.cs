using OVERLIMIT.Core.Messages.MainMenu;
using OVERLIMIT.Utility.Logging;
using OVERLIMIT.Utility.Validation;
using UnityEngine;
using UnityEngine.UI;

namespace OVERLIMIT.Features.MainMenu.Garage
{
    /// <summary>
    /// Handles the garage module infrastructure, binds interaction controls,
    /// and dispatches directional index shifting to the vehicle selector system.
    /// </summary>
    public class GarageController : MonoBehaviour
    {
        public GarageSelector selector;
        public GarageView view;

        [Header("Interaction Controls")]
        public Button nextButton;
        public Button prevButton;

        private void Start()
        {
            // Validates core garage sub-modules, button bindings, and vehicle registry allocations.
            if (
                this.BeginValidation()
                    .Require(selector, nameof(selector))
                    .Require(view, nameof(view))
                    .Require(nextButton, nameof(nextButton))
                    .Require(prevButton, nameof(prevButton))
                    .Require(
                        view?.SelectedCarText,
                        $"{nameof(view)}.{nameof(view.SelectedCarText)}"
                    )
                    .RequireList(
                        selector?.allCars,
                        $"{nameof(selector)}.{nameof(selector.allCars)}"
                    )
                    .LogAndCheck()
            )
                return;

            // Bind carousel index shifting triggers
            nextButton.onClick.AddListener(() => selector.SwitchCar(1));
            prevButton.onClick.AddListener(() => selector.SwitchCar(-1));

            OverLogger.LogSuccess(GarageMsg.PrevNextButton, this);
        }
    }
}
