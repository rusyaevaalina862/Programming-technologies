namespace game
{
    /// <summary>
    /// Интерфейс для реализации игры с заданным диапазоном значений.
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// Устанавливает диапазон значений для игры.
        /// </summary>
        /// <param name="min">Минимальное значение диапазона.</param>
        /// <param name="max">Максимальное значение диапазона.</param>
        void SetRange(int min, int max);

        /// <summary>
        /// Запускает игровой процесс.
        /// Вызывает логику игры и взаимодействие с пользователем.
        /// </summary>
        void Play();
    }
}
