using System;
using System.IO;
using System.Text;

namespace DesignPatterns.Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string testFilePath = "pg1513.txt";

            // Якщо файлу для тесту раптом немає, генеруємо тимчасовий великий файл
            if (!File.Exists(testFilePath)) {
                Console.WriteLine($"Файл {testFilePath} не знайдено. Генерую тестовий файл ...");
                GenerateFile(testFilePath);
            }

            var parser = new BookParser();

        
            // ТЕСТ 1: ВАЖКИЙ ПІДХІД (БЕЗ ЛЕГКОВАГОВИКА)
        
            Console.WriteLine("\n==============================================");
            Console.WriteLine(" ТЕСТ 1: ПАРСИНГ БЕЗ ЛЕГКОВАГОВИКА (HEAVY)");
            
            ForceGarbageCollection(); // Очищаємо пам'ять перед стартом
            Console.WriteLine("[ПАМ'ЯТЬ ДО ПАРСИНГУ]");
            MemoryMonitor.CheckCurrentProcess();

            // Парсимо
            HeavyElementNode heavyRoot = parser.ParseFileHeavy(testFilePath);

            Console.WriteLine("\n[ПАМ'ЯТЬ ПІСЛЯ СТВОРЕННЯ ВАЖКОГО ДЕРЕВА]");
            MemoryMonitor.CheckCurrentProcess();
            
            parser.SaveHtmlToFile(heavyRoot, "book_heavy");

            // Знищуємо важке дерево, щоб звільнити пам'ять для наступного тесту
            heavyRoot = null; 
            ForceGarbageCollection();


        
            // ТЕСТ 2: ОПТИМІЗОВАНИЙ ПІДХІД (З ЛЕГКОВАГОВИКОМ)
        
            Console.WriteLine("\n==============================================");
            Console.WriteLine(" ТЕСТ 2: ПАРСИНГ З ЛЕГКОВАГОВИКОМ (FLYWEIGHT)");
            
            Console.WriteLine("[ПАМ'ЯТЬ ДО ПАРСИНГУ]");
            MemoryMonitor.CheckCurrentProcess();

            // Парсимо
            FlyweightElementNode flyweightRoot = parser.ParseFileWithFlyWeight(testFilePath);

            Console.WriteLine("\n[ПАМ'ЯТЬ ПІСЛЯ СТВОРЕННЯ ЛЕГКОГО ДЕРЕВА]");
            MemoryMonitor.CheckCurrentProcess();
            
            Console.WriteLine($"\nКількість закешованих тегів у пулі: {TagFactory.CachedTagsCount}");

            parser.SaveHtmlToFile(flyweightRoot, "book_flyweight");

           // Console.ReadKey();
        }

        static void ForceGarbageCollection()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        static void GenerateFile(string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Заголовок книги");
                for (int i = 0; i < 100000; i++)
                    writer.WriteLine("Це звичайний довгий рядок тексту для перевірки об'єму пам'яті...");
            }
        }
    }
}