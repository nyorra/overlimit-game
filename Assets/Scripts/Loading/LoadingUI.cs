using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace OVERLIMIT.Loading
{
    public class LoadingUI : MonoBehaviour
    {
        [Header("UI References")]
        public Slider loadingProgressBar;
        public TMP_Text continueHintText;

        public void SetupInitialState()
        {
            if (loadingProgressBar == null || continueHintText == null) return;

            continueHintText.gameObject.SetActive(false);
            loadingProgressBar.gameObject.SetActive(true);
            loadingProgressBar.value = 0f;
        }

        public void UpdateProgress(float progress)
        {
            if (loadingProgressBar != null)
            {
                // Приводим 0.9f от AsyncOperation к 1.0f для слайдера
                loadingProgressBar.value = Mathf.Clamp01(progress / 0.9f);
            }
        }

        public void ShowReadyState()
        {
            if (loadingProgressBar != null) loadingProgressBar.gameObject.SetActive(false);
            if (continueHintText != null) continueHintText.gameObject.SetActive(true);
        }
    }
}
