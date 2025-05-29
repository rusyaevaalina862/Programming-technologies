using game;

namespace game;

/// <summary>
/// Класс для учета статистики игр.
/// Реализует интерфейс IStatistics.
/// </summary>
public class GameStatistics : IStatistics
{
    private int _minAttempts = int.MaxValue; // Минимальное количество попыток за игру
    private int _maxAttempts = 0; // Максимальное количество попыток за игру
    private int _totalAttempts = 0; // Общее количество попыток во всех играх
    private int _gamesCount = 0; // Количество сыгранных игр

    /// <summary>
    /// Проверяет, были ли сыграны игры.
    /// </summary>
    public bool HasPlayed => _gamesCount > 0;

    /// <summary>
    /// Метод для добавления количества попыток в статистику.
    /// Обновляет минимальное и максимальное количество попыток,
    /// а также суммирует общее количество попыток и увеличивает счетчик игр.
    /// </summary>
    /// <param name="attempts">Количество попыток в текущей игре.</param>
    public void AddAttempt(int attempts)
    {
        if (attempts < _minAttempts) _minAttempts = attempts; // Обновляем минимум, если текущие попытки меньше
        if (attempts > _maxAttempts) _maxAttempts = attempts; // Обновляем максимум, если текущие попытки больше

        _totalAttempts += attempts; // Суммируем общее количество попыток
        _gamesCount++; // Увеличиваем счетчик сыгранных игр
    }

    /// <summary>
    /// Реализация метода интерфейса IStatistics для добавления результата игры.
    /// Использует метод AddAttempt для обновления статистики.
    /// </summary>
    /// <param name="attempts">Количество попыток в текущей игре.</param>
    public void AddGameResult(int attempts)
    {
        AddAttempt(attempts); // Добавляем результат игры, используя существующий метод
    }

    /// <summary>
    /// Метод для получения статистики игр.
    /// Возвращает строку с минимальным, максимальным и средним количеством попыток.
    /// </summary>
    /// <returns>Строка с информацией о статистике.</returns>
    public string GetStatistics()
    {
        if (_gamesCount == 0)
            return "Нет сыгранных игр."; // Проверка на наличие сыгранных игр

        double avg = (double)_totalAttempts / _gamesCount; // Вычисление среднего количества попыток
        return $"Минимум попыток: {_minAttempts}\n" +
               $"Максимум попыток: {_maxAttempts}\n" +
               $"Среднее попыток: {avg:F2}"; // Форматированный вывод средней статистики
    }
}
