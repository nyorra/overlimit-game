using System.Collections;
using OVERLIMIT.Core;
using OVERLIMIT.Core.Messages.MainMenu;
using OVERLIMIT.Utility.Logging;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OVERLIMIT.Menu
{
    /// <summary>
    /// Lightweight scene loader for the main menu system.
    /// Utilized for immediate screen-to-screen routing and transitions.
    /// </summary>
    public class MenuLoader : MonoBehaviour
    {
        // Double-click mitigation flag to prevent duplicate loading dispatch requests.
        private bool _isLoading = false;

        /// Triggers the asynchronous scene transition pipeline.
        public void LoadScene(SceneType scene)
        {
            if (_isLoading)
                return;
            StartCoroutine(LoadRoutine(scene));
        }

        private IEnumerator LoadRoutine(SceneType scene)
        {
            _isLoading = true;
            string sceneName = scene.ToString();

            OverLogger.LogSuccess(SelfMainMenuMsg.LoadStarted(sceneName), this);

            // Dispatches immediate asynchronous level loading to Unity
            AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);

            if (op == null)
            {
                OverLogger.LogError(SelfMainMenuMsg.MainNotFound(sceneName), this);
                _isLoading = false;
                yield break;
            }

            // Stalls execution until the scene is fully finalized and active (unlike LoadingProcessor, this runs to absolute completion)
            while (!op.isDone)
            {
                yield return null;
            }
        }
    }
}
