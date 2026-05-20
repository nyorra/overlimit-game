using System.Collections;
using OVERLIMIT.Core;
using OVERLIMIT.Core.Messages.Loading;
using OVERLIMIT.Utility.Logging;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OVERLIMIT.Features.Loading
{
    /// <summary>
    /// Техническая часть загрузки
    /// Незаметно подгружает файлы сцены в память
    /// </summary>
    public class LoadingProcessor
    {
        // Связь с процессом загрузки Unity (нужна для отслеживания процентов)
        public AsyncOperation AsyncOperation { get; private set; }

        public IEnumerator LoadSceneRoutine(SceneType scene)
        {
            // Берем имя из списка сцен и просим Unity начать загрузку
            string sceneName = scene.ToString();
            AsyncOperation = SceneManager.LoadSceneAsync(sceneName);

            if (AsyncOperation == null)
            {
                OverLogger.LogError(SelfLoadingMsg.LoadNotFound(sceneName), null);
                yield break;
            }

            // Запрещаем игре сразу переключаться, пока мы не разрешим (через кнопку)
            AsyncOperation.allowSceneActivation = false;
            OverLogger.LogSuccess(SelfLoadingMsg.BackgroundLoading(sceneName), null);
            // Ждем, пока всё прогрузится в память (0.9 — это максимум для этого режима)
            while (AsyncOperation.progress < 0.9f)
            {
                yield return null;
            }

            OverLogger.LogSuccess(SelfLoadingMsg.WaitForUserInput, null);
        }

        public void ActivateScene()
        {
            // Разрешаем сменить сцену
            if (AsyncOperation != null)
            {
                AsyncOperation.allowSceneActivation = true;
            }
        }
    }
}
