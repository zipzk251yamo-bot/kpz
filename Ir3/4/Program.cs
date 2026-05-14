using System;
using System.IO;


namespace DesignPatterns.Proxy
{

    // 5. Демонстрація роботи програми
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Підготовка: створюємо два тестові файли для перевірки
            string publicFile = "public_data.txt";
            string secretFile = "secret_passwords.txt";
            
            File.WriteAllText(publicFile, "Перший рядок тексту.\nДругий рядок.");
            File.WriteAllText(secretFile, "SuperSecret123\nAdmin:root");

            // Базовий об'єкт (Real Subject)
            ITextReader baseReader = new SmartTextReader();

            Console.WriteLine("=== ТЕСТ 1: Використання SmartTextChecker (Логування) ===");
            ITextReader checkerProxy = new SmartTextChecker(baseReader);
            checkerProxy.ReadText(publicFile);

            Console.WriteLine("=== ТЕСТ 2: Використання SmartTextReaderLocker (Блокування файлів зі словом 'secret') ===");
            // Блокуємо доступ до будь-яких файлів, що містять слово "secret"
            ITextReader lockerProxy = new SmartTextReaderLocker(baseReader, "secret");
            
            Console.WriteLine("Спроба прочитати публічний файл через Locker:");
            lockerProxy.ReadText(publicFile); // Доступ дозволено (але без логування, бо це просто Locker)
            
            Console.WriteLine("Спроба прочитати секретний файл через Locker:");
            lockerProxy.ReadText(secretFile); // Access denied!

            Console.WriteLine("=== ТЕСТ 3: Ланцюжок проксі (Логування + Блокування) ===");
            // Ми можемо комбінувати проксі! Locker спочатку перевірить доступ, а Checker потім залогує
            ITextReader combinedProxy = new SmartTextChecker(new SmartTextReaderLocker(baseReader, "secret"));
            
            Console.WriteLine("Читаємо публічний файл (Ланцюжок):");
            combinedProxy.ReadText(publicFile);
            
            Console.WriteLine("Читаємо секретний файл (Ланцюжок):");
            combinedProxy.ReadText(secretFile);

            // Прибирання після тестів
            File.Delete(publicFile);
            File.Delete(secretFile);

            Console.ReadKey();
        }
    }
}