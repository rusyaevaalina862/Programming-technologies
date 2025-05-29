using game; // Подключаем пространство имен для классов игры
using System; // Подключаем пространство имен для работы с базовыми функциональными возможностями .NET

/// <summary>
/// Главный класс программы, содержащий точку входа.
/// </summary>
class Program
{
    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    public static void Main()
    {
        // Создаем экземпляр класса GameStatistics для хранения статистики игры.
        var statistics = new GameStatistics();

        // Устанавливаем уровень сложности по умолчанию на средний.
        DifficultyLevel difficulty = DifficultyLevel.Medium;

        // Выводим меню выбора уровня сложности для пользователя.
        Console.WriteLine("Выберите уровень сложности:\n1. Легкий\n2. Средний\n3. Тяжелый");

        int choice; // Переменная для хранения выбора пользователя.

        // Цикл для получения корректного ввода от пользователя.
        while (true)
        {
            // Пытаемся считать ввод пользователя и проверяем его корректность.
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 3)
            {
                break; // Если ввод корректен (1, 2 или 3), выходим из цикла.
            }
            // Если ввод некорректен, просим пользователя попробовать снова.
            Console.WriteLine("Некорректный выбор, попробуйте снова (1-3): ");
        }

        // Устанавливаем уровень сложности в зависимости от выбора пользователя.
        switch (choice)
        {
            case 1:
                difficulty = DifficultyLevel.Easy; // Легкий уровень сложности
                break;
            case 2:
                difficulty = DifficultyLevel.Medium; // Средний уровень сложности
                break;
            case 3:
                difficulty = DifficultyLevel.Hard; // Тяжелый уровень сложности
                break;
        }

        // Создаем экземпляр игры GuessNumberGame с выбранной сложностью и статистикой.
        var game = new GuessNumberGame(statistics, difficulty);

        // Создаем экземпляр меню для управления игрой.
        var menu = new ConsoleMenu();

        // Создаем контроллер игры, который связывает игру, меню и статистику.
        var controller = new GameController(game, menu, statistics);

        // Запускаем игру, инициируя цикл обработки событий и взаимодействия с пользователем.
        controller.Run();
    }
}
