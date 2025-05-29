namespace game
{
    /// <summary>
    /// Класс ConsoleMenu реализует пользовательский интерфейс в виде консольного меню.
    /// Предлагает пользователю выбрать одно из действий и обеспечивает обработку ввода.
    /// </summary>
    public class ConsoleMenu : IMenu
    {
        /// <summary>
        /// Отображает меню с доступными для выбора опциями.
        /// </summary>
        public void Show()
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Изменить диапазон");
            Console.WriteLine("2. Начать новую игру");
            Console.WriteLine("3. Посмотреть статистику");
            Console.WriteLine("4. Выйти");
            Console.Write("Выберите действие: ");
        }

        /// <summary>
        /// Получает пользовательский выбор, проверяет его корректность и возвращает выбранное число.
        /// В случае некорректного ввода запрашивает повторно.
        /// </summary>
        /// <returns>Число, выбранное пользователем (от 1 до 4).</returns>
        public int GetUserChoice()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    // Проверка, что введенное число находится в допустимом диапазоне
                    if (choice >= 1 && choice <= 4)
                    {
                        return choice;
                    }
                }
                // Сообщение об ошибке и повторный запрос ввода
                Console.WriteLine("Некорректный выбор, попробуйте снова.");
            }
        }
    }
}