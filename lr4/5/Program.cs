using System;

namespace DesignPatterns.Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Текстовий редактор (Паттерн Memento) ===\n");

            // 1. Ініціалізуємо документ та редактор
            TextDocument document = new TextDocument("Початковий текст. ");
            TextEditor editor = new TextEditor();

            document.Print();

            // 2. Зберігаємо початковий стан
            editor.Backup(document.Save());

            // 3. Змінюємо текст і зберігаємо знову
            System.Threading.Thread.Sleep(1000); // Затримка для різного часу знімків
            document.AddText("Пишемо перший абзац. ");
            document.Print();
            editor.Backup(document.Save());

            // 4. Робимо ще одну зміну (але НЕ зберігаємо її)
            document.AddText("Пишемо рядок з помилкою!!! ");
            document.Print();

            // 5. Дивимося історію доступних бекапів
            editor.ShowHistory();

            // 6. Користувач натискає "Скасувати" (Undo)
            Console.WriteLine(">>> Натиснуто Ctrl+Z (Undo) <<<");
            editor.Undo();
            document.Print(); // Має зникнути рядок з помилкою

            // 7. Робимо "Undo" ще раз
            Console.WriteLine("\n>>> Натиснуто Ctrl+Z (Undo) <<<");
            editor.Undo();
            document.Print(); // Має залишитись лише "Початковий текст."

            Console.ReadKey();
        }
    }
}