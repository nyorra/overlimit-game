using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;
using OVERLIMIT.Scenes;
using OVERLIMIT.Logging;

namespace OVERLIMIT.Loading
{
    public class LoadingScreen : MonoBehaviour
    {
        public Slider LoadingProgressBar;
        public TMP_Text ContinueHintText;
        public SceneType nextScene;

        void Start()
        {
            // Проверка на подключение UI элементов
            if (LoadingProgressBar == null || ContinueHintText == null)
            {
                OverLogger.LogError("Ошибка: В инспекторе LoadingScreen не назначены ссылки на UI!", this);
                return;
            }

            ContinueHintText.gameObject.SetActive(false);
            LoadingProgressBar.gameObject.SetActive(true);
            LoadingProgressBar.value = 0f;

            // Запускаем универсальную корутину загрузки
            StartCoroutine(LoadSceneRoutine());

            OverLogger.LogSuccess($"Процесс загрузки инициирован. Целевая сцена: {nextScene}", this);
        }

        IEnumerator LoadSceneRoutine()
        {
            string sceneName = nextScene.ToString();
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

            if (asyncLoad == null)
            {
                OverLogger.LogError($"Критическая ошибка: Не удалось начать асинхронную загрузку {sceneName}!");
                yield break;
            }

            // Блокируем автоматический переход
            asyncLoad.allowSceneActivation = false;

            // Обновление прогресс-бара
            while (asyncLoad.progress < 0.9f)
            {
                LoadingProgressBar.value = Mathf.Clamp01(asyncLoad.progress / 0.9f);
                yield return null;
            }

            LoadingProgressBar.value = 1f;
            LoadingProgressBar.gameObject.SetActive(false);
            ContinueHintText.gameObject.SetActive(true);

            OverLogger.LogSuccess($"Сцена [{sceneName}] успешно загружена в память. Ожидаю ввод игрока...");

            // Ожидание клика или клавиши
            yield return new WaitUntil(() =>
                (Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame) ||
                (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame));

            OverLogger.LogSuccess($"Активация сцены [{sceneName}]. Переход выполнен успешно!", this);

            asyncLoad.allowSceneActivation = true;
        }
    }
}
