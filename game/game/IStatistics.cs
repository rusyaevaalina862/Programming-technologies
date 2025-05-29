
namespace game
{
    /// <summary>
    /// Интерфейс для работы со статистикой игры.
    /// Предоставляет методы для добавления результатов игр и получения статистики.
    /// </summary>
    public interface IStatistics
    {
        /// <summary>
        /// Добавляет результат игры, фиксируя количество попыток.
        /// </summary>
        /// <param name="attempts">Количество попыток, сделанных игроком в текущей игре.</param>
        void AddGameResult(int attempts);

        /// <summary>
        /// Получает строковое представление статистики игр.
        /// </summary>
        /// <returns>Строка, содержащая информацию о сыгранных играх и их результатах.</returns>
        string GetStatistics();

        /// <summary>
        /// Указывает, играл ли игрок хотя бы одну игру.
        /// </summary>
        bool HasPlayed { get; }
    }
}