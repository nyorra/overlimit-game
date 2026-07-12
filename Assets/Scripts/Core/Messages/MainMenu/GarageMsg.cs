namespace OVERLIMIT.Core.Messages.MainMenu
{
    public static class GarageMsg
    {
        public static string Switched(string car) => $"Выбранная машина изменена на: {car}";

        public static string Updated(string target) =>
            $"Поле отображения SelectCarText обновлено. Выбранная машина: {target}";

        public static string PrevNextButton = "Кнопки выбора prev/next доабвлены";
        public static string InitializedSelector = "Селектор успешно запущена.";
    }
}
