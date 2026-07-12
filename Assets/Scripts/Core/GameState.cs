using UnityEngine;

namespace OVERLIMIT.Core
{
    public enum MachineState
    {
        Idle, // Покой
        Moving, // Движение по земле
        Flying, // В полете
    }

    /// <summary>
    /// Класс для отслеживания игровых состояний
    /// </summary>
    public class GameState : MonoBehaviour { }
}
