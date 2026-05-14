using System;

namespace DesignPatterns.Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1. Робота зі звичайним логером 
            Logger consoleLogger = new Logger();
            Console.WriteLine("--- Робота консольного логера ---");
            consoleLogger.Log("Програма запущена");
            consoleLogger.Warn("Мало оперативної пам'яті");
            consoleLogger.Error("Критична помилка доступу");

            Console.WriteLine();

            // 2. Робота з файловим логером через Адаптер
            FileWriter writer = new FileWriter();
            Logger fileLogger = new FileLoggerAdapter(writer);

            Console.WriteLine("--- Робота файлового логера (запис у log.txt) ---");
            fileLogger.Log("Запис у файл через адаптер");
            fileLogger.Warn("Попередження записано у файл");
            fileLogger.Error("Помилка записана у файл");

            Console.WriteLine("Дані успішно збережені. Перевірте файл log.txt у папці з програмою.");
            
            Console.ReadKey();
        }
    }
}