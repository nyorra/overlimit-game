using System.Collections;
using OVERLIMIT.Core;
using OVERLIMIT.Core.Messages.Loading;
using OVERLIMIT.Utility.Logging;
using OVERLIMIT.Utility.Validation;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OVERLIMIT.Features.Loading
{
    /// <summary>
    /// Manages the loading screen lifecycle, coordinating the loading processor,
    /// user interface updates, and user input detection.
    /// </summary>
    public class LoadingController : MonoBehaviour
    {
        // The destination scene to activate after receiving user input.
        public SceneType nextScene;

        [Header("References")]
        [SerializeField]
        private LoadingView ui;
        private LoadingProcessor _processor;

        void Start()
        {
            // Validates the entire LOADING module dependencies at once.
            if (
                this.BeginValidation()
                    .Require(ui, nameof(ui))
                    .Require(
                        ui?.loadingProgressBar,
                        $"{nameof(ui)}.{nameof(ui.loadingProgressBar)}"
                    )
                    .Require(ui?.continueHintText, $"{nameof(ui)}.{nameof(ui.continueHintText)}")
                    .LogAndCheck()
            )
                return;

            _processor = new LoadingProcessor();
            ui.SetupInitialState();
            StartCoroutine(MasterRoutine());
        }

        private IEnumerator MasterRoutine()
        {
            // Executes the background loading task.
            yield return StartCoroutine(LoadingSequence());

            // Scene background loading is complete.
            ui.ShowReadyState();

            // Halts execution until any valid user interaction is detected.
            yield return new WaitUntil(() =>
                (Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame)
                || (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            );

            OverLogger.LogSuccess(SelfLoadingMsg.InputReceived(nextScene.ToString()), this);
            _processor.ActivateScene();
        }

        private IEnumerator LoadingSequence()
        {
            // Dispatches the async scene loading routine to the processor.
            IEnumerator loadTask = _processor.LoadSceneRoutine(nextScene);
            StartCoroutine(loadTask);

            // Pumps the asynchronous progress statistics directly into the view layer.
            while (_processor.AsyncOperation == null || _processor.AsyncOperation.progress < 0.9f)
            {
                if (_processor.AsyncOperation != null)
                {
                    ui.UpdateProgress(_processor.AsyncOperation.progress);
                }
                yield return null;
            }

            ui.UpdateProgress(0.9f); // Artificially fills the bar to 100% since 0.9f means fully loaded but unactivated.
        }
    }
}
