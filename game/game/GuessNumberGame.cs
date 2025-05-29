using game;

public class GuessNumberGame : IGame
{
    private int _min; // Минимальное значение диапазона для угадывания
    private int _max; // Максимальное значение диапазона для угадывания
    private readonly IStatistics _statistics; // Объект для учета статистики игр
    private readonly Random _random; // Генератор случайных чисел
    private int _maxAttempts; // Максимальное количество попыток для угадывания
    private int _numberToGuess; // Загаданное число

    /// <summary>
    /// Конструктор класса GuessNumberGame.
    /// Инициализирует параметры игры и генерирует загаданное число.
    /// </summary>
    /// <param name="statistics">Объект для учета статистики игр.</param>
    /// <param name="difficulty">Уровень сложности игры.</param>
    /// <param name="min">Минимальное значение диапазона.</param>
    /// <param name="max">Максимальное значение диапазона.</param>
    public GuessNumberGame(IStatistics statistics, DifficultyLevel difficulty = DifficultyLevel.Medium, int min = 1, int max = 100)
    {
        _statistics = statistics;
        _min = min;
        _max = max;
        _random = new Random();
        SetDifficulty(difficulty);
        GenerateNumber();
    }

    /// <summary>
    /// Устанавливает диапазон значений для угадывания.
    /// Генерирует новое загаданное число в заданном диапазоне.
    /// </summary>
    /// <param name="min">Минимальное значение диапазона.</param>
    /// <param name="max">Максимальное значение диапазона.</param>
    public void SetRange(int min, int max)
    {
        if (min > max)
        {
            // Меняем местами значения, если минимальное больше максимального
            int temp = min;
            min = max;
            max = temp;
        }
        _min = min;
        _max = max;
        GenerateNumber(); // Генерируем новое загаданное число
    }

    /// <summary>
    /// Устанавливает уровень сложности игры и максимальное количество попыток.
    /// </summary>
    /// <param name="difficulty">Уровень сложности.</param>
    private void SetDifficulty(DifficultyLevel difficulty)
    {
        switch (difficulty)
        {
            case DifficultyLevel.Easy:
                _maxAttempts = 10; // Легкий уровень - 10 попыток
                break;
            case DifficultyLevel.Medium:
                _maxAttempts = 7; // Средний уровень - 7 попыток
                break;
            case DifficultyLevel.Hard:
                _maxAttempts = 5; // Сложный уровень - 5 попыток
                break;
        }
    }

    /// <summary>
    /// Генерирует случайное число для угадывания в заданном диапазоне.
    /// </summary>
    private void GenerateNumber()
    {
        _numberToGuess = _random.Next(_min, _max + 1); // Генерация числа в диапазоне от _min до _max
    }

    /// <summary>
    /// Запускает игровой процесс, позволяя пользователю угадывать число.
    /// </summary>
    public void Play()
    {
        Console.WriteLine($"Угадайте число от {_min} до {_max} за максимум {_maxAttempts} попыток");
        int attempts = 0;

        while (attempts < _maxAttempts)
        {
            Console.Write($"Попытка {attempts + 1}: ");
            // Проверяем ввод пользователя на корректность
            if (!int.TryParse(Console.ReadLine(), out int guess) || guess < _min || guess > _max)
            {
                Console.WriteLine("Некорректный ввод, попробуйте снова.");
                continue; // Продолжаем цикл, если ввод некорректный
            }

            attempts++; // Увеличиваем счетчик попыток

            if (guess == _numberToGuess)
            {
                Console.WriteLine($"Поздравляем! Вы угадали за {attempts} попыток");
                _statistics.AddGameResult(attempts); // Сохраняем результат в статистику
                return; // Завершаем игру при правильном ответе
            }
            else if (guess > _numberToGuess)
            {
                Console.WriteLine("Меньше"); // Подсказка, если введенное число больше загаданного
            }
            else
            {
                Console.WriteLine("Больше"); // Подсказка, если введенное число меньше загаданного
            }
        }

        Console.WriteLine($"К сожалению, попытки исчерпаны. Загаданное число было {_numberToGuess}."); // Сообщение о проигрыше
    }
}
