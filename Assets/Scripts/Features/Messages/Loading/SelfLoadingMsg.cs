namespace OVERLIMIT.Core.Messages.Loading
{
    /// <summary>
    /// Центр сообщений модуля Loading
    /// </summary>
    public static class SelfLoadingMsg
    {
        public static string BackgroundLoading(string name) => $"Фоновая загрузка [{name}]...";

        public static string WaitForUserInput = "Загрузка завершена. Ожидание ввода пользователя.";
        public static string ReadyHintShown = "Нажмите кнопку для продолжения прогружена";

        public static string InputReceived(string sceneName) =>
            $"Получен ввод игрока, переход в {sceneName}";

        public static string LoadNotFound(string name) => $"{name} не найдена в Build Settings!";
    }
}
