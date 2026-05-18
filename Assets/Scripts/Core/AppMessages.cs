using System.Net.NetworkInformation;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

namespace OVERLIMIT.Messages
{
    /// <summary>
    /// Единый центр всех текстовых сообщений проекта.
    /// Все разбито по модулю, возможны дубли
    /// Пока что так - для лучшей читаемости
    /// </summary>
    public static class AppMessages
    {
        // загрузочный экран
        public static class Loading
        {
            public static string BackgroundLoading(string name) => $"Фоновая загрузка [{name}]...";

            public static string WaitForUserInput =
                "Загрузка завершена. Ожидание ввода пользователя.";
            public static string ReadyHintShown = "Нажмите кнопку для продолжения прогружена";

            public static string InputReceived(string sceneName) =>
                $"Получен ввод игрока, переход в {sceneName}";

            /// ошибки
            public static string LoadNotFound(string name) =>
                $"{name} не найдена в Build Settings!";
        }

        // главное меню
        public static class MainMenu
        {
            // главное меню
            public static string MenuReady = "Все связи и кнопки настроены.";

            public static string LoadStarted(string name) => $"Начата загрузка: {name}";

            public static string MainNotFound(string name) =>
                $"{name} не найдена в Build Settings!";

            public static string PanelOpened(string name) => $"Открыта панель: {name}";

            // В город
            public static class City { }

            // гараж
            public static class Garage
            {
                public static string Switched(string car) => $"Выбранная машина изменена на: {car}";

                public static string Updated(string target) =>
                    $"Поле отображения SelectCarText обновлено. Выбранная машина: {target}";

                public static string PrevNextButton = "Кнопки выбора prev/next доабвлены";
                public static string InitializedSelector = "Селектор успешно запущена.";
            }

            // настройки
            public static class Settings { }

            // авторы
            public static class Credits { }
        }

        // Город
        public static class City
        {
            public static string SelectNull = "нет выбранной машины";

            public static class Camera
            {
                public static string NoCamTarger =
                    "Не выбран camTarget, объект для следования камеры";
            }
        }

        // Все, что касается валидации связей в инспекторе
        public static class Validation
        {
            public static string Missing(string field) => $"Не назначен компонент: {field}";

            public static string NestedMissing(string parent, string field) =>
                $"Внутри [{parent}] не назначен: {field}";
        }

        // // Кастомный логгер
        // public static class Logging
        // {

        // }
    }
}
