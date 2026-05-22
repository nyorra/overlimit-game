namespace OVERLIMIT.Core.Messages.City
{
    /// <summary>
    /// Сообщения контроллера машин
    /// </summary>
    public static class CarMsg
    {
        public static string MovingByY = "Движение по оси Z: {_throttleInput}";
        public static string TurnByX = "Поворот по оси Y: {_steeringInput}";
        public static string AddedForce = "Добавлена сила {ForwardForce}";
        public static string AddedTorque = "Добавлена сила {turnTorque}";
    }
}
