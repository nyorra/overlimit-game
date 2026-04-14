using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using OVERLIMIT.Scenes;
using OVERLIMIT.Logging;

namespace OVERLIMIT.Menu
{
    public class MainMenuLoader : MonoBehaviour
    {
        public void LoadScene(SceneType scene)
        {
            StartCoroutine(LoadRoutine(scene));
        }

        private IEnumerator LoadRoutine(SceneType scene)
        {
            string sceneName = scene.ToString();
            OverLogger.LogSuccess($"Запущен процесс загрузки сцены: {sceneName}", this);

            AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);

            if (op == null)
            {
                OverLogger.LogError($"Критическая ошибка: Сцена {sceneName} не найдена в Build Settings!");
                yield break;
            }

            while (!op.isDone)
            {
                yield return null;
            }

            OverLogger.LogSuccess($"Сцена {sceneName} успешно загружена.");
        }
    }
}
