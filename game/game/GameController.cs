using game;

namespace game;

/// <summary>
/// Контроллер игры, отвечающий за взаимодействие между игровым процессом,
/// меню и статистикой. Управляет диапазоном чисел для игры.
/// </summary>
public class GameController
{
    private readonly IGame _game; // Интерфейс игры
    private readonly IMenu _menu; // Интерфейс меню
    private readonly IStatistics _statistics; // Интерфейс статистики
    private int _lowerBound; // Нижняя граница диапазона
    private int _upperBound; // Верхняя граница диапазона

    /// <summary>
    /// Конструктор контроллера игры.
    /// Инициализирует игровые компоненты и устанавливает начальный диапазон.
    /// </summary>
    /// <param name="game">Экземпляр игры, реализующий интерфейс IGame.</param>
    /// <param name="menu">Экземпляр меню, реализующий интерфейс IMenu.</param>
    /// <param name="statistics">Экземпляр статистики, реализующий интерфейс IStatistics.</param>
    /// <param name="min">Начальная нижняя граница диапазона (по умолчанию 1).</param>
    /// <param name="max">Начальная верхняя граница диапазона (по умолчанию 100).</param>
    public GameController(IGame game, IMenu menu, IStatistics statistics, int min = 1, int max = 100)
    {
        _game = game;
        _menu = menu;
        _statistics = statistics;
        _lowerBound = min;
        _upperBound = max;
        _game.SetRange(_lowerBound, _upperBound); // Устанавливаем диапазон для игры
    }

    /// <summary>
    /// Метод для запуска игрового процесса.
    /// Отображает меню и обрабатывает выбор пользователя.
    /// </summary>
    public void Run()
    {
        while (true)
        {
            _menu.Show(); // Показываем меню пользователю
            int choice = _menu.GetUserChoice(); // Получаем выбор пользователя

            switch (choice)
            {
                case 1:
                    // Изменение диапазона
                    Console.Write("Введите нижнюю границу: ");
                    if (int.TryParse(Console.ReadLine(), out int newMin))
                    {
                        Console.Write("Введите верхнюю границу: ");
                        if (int.TryParse(Console.ReadLine(), out int newMax))
                        {
                            _lowerBound = newMin; // Устанавливаем новую нижнюю границу
                            _upperBound = newMax; // Устанавливаем новую верхнюю границу
                            _game.SetRange(_lowerBound, _upperBound); // Обновляем диапазон в игре
                            Console.WriteLine($"Диапазон изменен на [{_lowerBound}; {_upperBound}]");
                        }
                    }
                    break;
                case 2:
                    // Запуск игры
                    _game.Play(); // Начинаем игровую сессию
                    break;
                case 3:
                    // Показ статистики
                    Console.WriteLine(_statistics.GetStatistics()); // Выводим статистику игр
                    break;
                case 4:
                    // Выход из игры
                    Console.WriteLine("Выход. До свидания!");
                    return; // Завершаем выполнение метода Run
            }
        }
    }
}
