using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using OVERLIMIT.Scenes;
using OVERLIMIT.Logging;

namespace OVERLIMIT.Loading
{
    public class LoadingScreen : MonoBehaviour
    {
        public SceneType nextScene;

        [Header("Components")]
        [SerializeField] private LoadingUI ui;

        private LoadingProcessor _processor;

        void Start()
        {
            if (ui == null)
            {
                OverLogger.LogError("Ошибка: В LoadingScreen не назначена ссылка на LoadingUI!", this);
                return;
            }

            _processor = new LoadingProcessor();
            ui.SetupInitialState();

            StartCoroutine(MasterRoutine());

            OverLogger.LogSuccess($"Загрузка инициирована. Цель: {nextScene}", this);
        }

        private IEnumerator MasterRoutine()
        {
            // 1. Запускаем логику загрузки в процессоре
            yield return StartCoroutine(_processor.LoadSceneRoutine(nextScene));

            // 2. Когда загрузилось — обновляем UI
            ui.UpdateProgress(0.9f); // Визуально это будет 100%
            ui.ShowReadyState();

            OverLogger.LogSuccess("Сцена в памяти. Ожидание ввода...", this);

            // 3. Ждем ввода игрока
            yield return new WaitUntil(() =>
                (Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame) ||
                (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame));

            // 4. Активируем сцену
            OverLogger.LogSuccess("Активация сцены...", this);
            _processor.ActivateScene();
        }
    }
}
