using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using OVERLIMIT.Scenes;

namespace OVERLIMIT.Loading
{
    public class LoadingProcessor
    {
        public AsyncOperation AsyncOperation { get; private set; }

        public IEnumerator LoadSceneRoutine(SceneType scene)
        {
            string sceneName = scene.ToString();
            AsyncOperation = SceneManager.LoadSceneAsync(sceneName);

            if (AsyncOperation == null) yield break;

            // Блокируем автоматический переход
            AsyncOperation.allowSceneActivation = false;

            // Ждем, пока сцена загрузится в память (до 90%)
            while (AsyncOperation.progress < 0.9f)
            {
                yield return null;
            }
        }

        public void ActivateScene()
        {
            if (AsyncOperation != null)
            {
                AsyncOperation.allowSceneActivation = true;
            }
        }
    }
}
