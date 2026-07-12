using System.Collections;
using OVERLIMIT.Core;
using OVERLIMIT.Core.Messages.Loading;
using OVERLIMIT.Utility.Logging;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OVERLIMIT.Features.Loading
{
    /// <summary>
    /// Core loading processor.
    /// Handles asynchronous scene asset streaming and background caching into memory.
    /// </summary>
    public class LoadingProcessor
    {
        // Reference to the Unity async task, utilized by the controller layer to poll progress updates.
        public AsyncOperation AsyncOperation { get; private set; }

        public IEnumerator LoadSceneRoutine(SceneType scene)
        {
            // Converts the enum to its exact string representation and dispatches the async load request to Unity.
            string sceneName = scene.ToString();
            AsyncOperation = SceneManager.LoadSceneAsync(sceneName);

            if (AsyncOperation == null)
            {
                OverLogger.LogError(SelfLoadingMsg.LoadNotFound(sceneName), null);
                yield break;
            }

            // Holds scene transition until explicit permission is given (e.g., via user input trigger).
            AsyncOperation.allowSceneActivation = false;
            OverLogger.LogSuccess(SelfLoadingMsg.BackgroundLoading(sceneName), null);
            // Stalls execution until the scene assets are fully buffered into RAM (0.9f is the maximum value before activation).
            while (AsyncOperation.progress < 0.9f)
            {
                yield return null;
            }

            OverLogger.LogSuccess(SelfLoadingMsg.WaitForUserInput, null);
        }

        public void ActivateScene()
        {
            // Releases the scene hold, allowing Unity to instantly switch to the freshly cached level.
            if (AsyncOperation != null)
            {
                AsyncOperation.allowSceneActivation = true;
            }
        }
    }
}
