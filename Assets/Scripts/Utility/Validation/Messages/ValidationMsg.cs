namespace OVERLIMIT.Core.Messages.Utility
{
    /// <summary>
    /// Сообщения контроллера машин
    /// </summar
    public static class ValidationMsg
    {
        public static string Missing(string field) => $"Не назначен компонент: {field}";

        public static string NestedMissing(string parent, string field) =>
            $"Внутри [{parent}] не назначен: {field}";

        public static string Success(string objectName) =>
            $"Все компоненты объекта [{objectName}] успешно валидированы.";
    }
}
