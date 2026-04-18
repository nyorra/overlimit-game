using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using OVERLIMIT.Scenes;
using OVERLIMIT.Logging;
using OVERLIMIT.Validate;
using OVERLIMIT.Messages;

namespace OVERLIMIT.Loading
{
    /// <summary>
    /// Управляет жизненным циклом экрана загрузки. координирует работу процессора загрузки, 
    /// обновление интерфейса и ожидание ввода пользователя.
    /// </summary>
    public class LoadingController : MonoBehaviour
    {
        // На какую сцену переключимся после user input
        public SceneType nextScene;

        // Ссылки на UI и загрузку сцены
        [Header("References")]
        [SerializeField] private LoadingView ui;
        private LoadingProcessor _processor;

        void Start()
        {
            // Валидируем весь модуль LOADING разом в одном месте
            if (this.BeginValidation()
                    .Require(ui, nameof(ui))
                    .Require(ui?.loadingProgressBar, $"{nameof(ui)}.{nameof(ui.loadingProgressBar)}")
                    .Require(ui?.continueHintText, $"{nameof(ui)}.{nameof(ui.continueHintText)}")
                    .LogAndCheck())
                return;

            _processor = new LoadingProcessor();
            ui.SetupInitialState();
            StartCoroutine(MasterRoutine());
        }

        private IEnumerator MasterRoutine()
        {
            // Запускаем загрузку
            yield return StartCoroutine(LoadingSequence());

            // Сцена готова
            ui.ShowReadyState();

            // Ждем ввод
            yield return new WaitUntil(() =>
                (Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame) ||
                (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame));

            OverLogger.LogSuccess(AppMessages.Loading.InputReceived(nextScene.ToString()), this);
            _processor.ActivateScene();
        }

        private IEnumerator LoadingSequence()
        {
            // Запускаем корутину в процессоре
            IEnumerator loadTask = _processor.LoadSceneRoutine(nextScene);
            StartCoroutine(loadTask);

            // Пока процессор делает работу,  обновляем UI
            while (_processor.AsyncOperation == null || _processor.AsyncOperation.progress < 0.9f)
            {
                if (_processor.AsyncOperation != null)
                {
                    ui.UpdateProgress(_processor.AsyncOperation.progress);
                }
                yield return null;
            }

            ui.UpdateProgress(0.9f); // Добиваем до 100% визуально
        }
    }
}
