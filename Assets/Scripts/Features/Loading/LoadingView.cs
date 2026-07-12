using OVERLIMIT.Core.Messages.Loading;
using OVERLIMIT.Utility.Logging;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OVERLIMIT.Features.Loading
{
    /// <summary>
    /// UI View layer for the loading screen.
    /// Drives the progress bar value and toggles localized visibility states for text prompts.
    /// </summary>
    public class LoadingView : MonoBehaviour
    {
        [Header("UI References")]
        public Slider loadingProgressBar; // Visual progress bar indicator.
        public TMP_Text continueHintText; // Interaction prompt text (e.g., "Press any key to continue").

        // Resets the UI components to their baseline loading states.
        public void SetupInitialState()
        {
            continueHintText.gameObject.SetActive(false);
            loadingProgressBar.gameObject.SetActive(true);
            loadingProgressBar.value = 0f;
        }

        // Updates the progress slider value with safe normalization.
        public void UpdateProgress(float progress)
        {
            if (loadingProgressBar != null)
            {
                // Unity stops loading progress at 0.9f. We normalize it by dividing
                // by 0.9f to ensure the slider fills to 1.0f (100%).
                loadingProgressBar.value = Mathf.Clamp01(progress / 0.9f);
            }
        }

        // Swaps the progress indicator with the user entry interaction prompt.
        public void ShowReadyState()
        {
            // Hides the progress bar and exposes the entry hint once the buffer is filled.
            loadingProgressBar?.gameObject.SetActive(false);
            continueHintText?.gameObject.SetActive(true);
            OverLogger.LogSuccess(SelfLoadingMsg.ReadyHintShown, this);
        }
    }
}
