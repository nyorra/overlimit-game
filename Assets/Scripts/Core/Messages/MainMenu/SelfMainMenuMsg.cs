namespace OVERLIMIT.Core.Messages.MainMenu
{
    public static class SelfMainMenuMsg
    {
        // главное меню
        public static string MenuReady = "Все связи и кнопки настроены.";

        public static string LoadStarted(string name) => $"Начата загрузка: {name}";

        public static string MainNotFound(string name) => $"{name} не найдена в Build Settings!";

        public static string PanelOpened(string name) => $"Открыта панель: {name}";
    }
}
