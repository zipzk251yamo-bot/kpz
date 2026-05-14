using System;
using System.IO;
using System.Text.RegularExpressions;

namespace DesignPatterns.Proxy
{
    // 1. Спільний інтерфейс для реального об'єкта та проксі
    public interface ITextReader
    {
        char[][] ReadText(string filePath);
    }

    // 2. Реальний об'єкт 
    // Читає файл і перетворює його на двомірний масив символів
    public class SmartTextReader : ITextReader
    {
        public char[][] ReadText(string filePath)
        {
            // Зчитуємо всі рядки з файлу
            string[] lines = File.ReadAllLines(filePath);

            // Створюємо двомірний масив: зовнішній - рядки, внутрішній - символи
            char[][] result = new char[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                //Console.WriteLine(lines[i].ToCharArray());
                result[i] = lines[i].ToCharArray();
            }
            
            return result;
        }
    }

    // 3. Проксі з логуванням (Proxy Pattern)
    public class SmartTextChecker : ITextReader
    {
        private ITextReader _reader;

        public SmartTextChecker(ITextReader reader)
        {
            _reader = reader;
        }

        public char[][] ReadText(string filePath)
        {
            Console.WriteLine($"[Log] Успішно відкрито файл: {filePath}");

            // Викликаємо метод реального об'єкта
            char[][] result = _reader.ReadText(filePath);

            Console.WriteLine($"[Log] Файл успішно прочитано.");

            if (result != null)
            {
                int lineCount = result.Length;
                int charCount = 0;

                foreach (var line in result)
                {
                    charCount += line.Length;
                }

                Console.WriteLine($"[Log] Загальна кількість рядків: {lineCount}");
                Console.WriteLine($"[Log] Загальна кількість символів: {charCount}");
            }

            Console.WriteLine($"[Log] Файл закрито: {filePath}\n");

            return result;
        }
    }

    // 4. Проксі з обмеженням доступу (Protection Proxy)
    public class SmartTextReaderLocker : ITextReader
    {
        private ITextReader _reader;
        private Regex _blacklistRegex;

        public SmartTextReaderLocker(ITextReader reader, string pattern)
        {
            _reader = reader;
            _blacklistRegex = new Regex(pattern);
        }

        public char[][] ReadText(string filePath)
        {
            // Перевіряємо, чи підпадає назва файлу під заборонений регулярний вираз
            if (_blacklistRegex.IsMatch(filePath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Access denied! (Доступ до '{filePath}' заборонено)\n");
                Console.ResetColor();
                return null; // Або можна викинути Exception
            }

            // Якщо доступ дозволено, передаємо виклик далі
            return _reader.ReadText(filePath);
        }
    }

}