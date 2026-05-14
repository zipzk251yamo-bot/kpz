
namespace DesignPatterns.Prototype;
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // 1. Створюємо 3 покоління вірусів
        // Покоління 1
        Virus grandParent = new Virus("Alpha", 1.5, 10, "Flu");

        // Покоління 2
        Virus parent1 = new Virus("Beta-1", 0.8, 5, "Flu");
        Virus parent2 = new Virus("Beta-2", 0.9, 4, "Flu");
        grandParent.AddChild(parent1);
        grandParent.AddChild(parent2);

        // Покоління 3
        Virus child = new Virus("Gamma-1.1", 0.2, 1, "Flu");
        parent1.AddChild(child);

        Console.WriteLine("--- ОРИГІНАЛЬНЕ СІМЕЙСТВО ---");
        Console.WriteLine(grandParent);

        // 2. Клонуємо все сімейство за допомогою патерну Прототип
        Virus clonedFamily = (Virus)grandParent.Clone();

        // 3. Змінюємо дані в клонованому сімействі для перевірки глибокого копіювання
        clonedFamily.SetName("Alpha-CLONE");
        // Отримуємо "дитину" з клонованого списку (Beta-1) та змінюємо її ім'я
        
        Console.WriteLine("\n--- ПІСЛЯ КЛОНУВАННЯ ТА МОДИФІКАЦІЇ КЛОНУ ---");
        Console.WriteLine("Оригінал (не має змінитись):");
        Console.WriteLine(grandParent);
        
        Console.WriteLine("\nКлон (змінено ім'я та структуру):");
        Console.WriteLine(clonedFamily);

        // Перевірка рівності посилань на дітей
        Console.WriteLine("\n--- ПЕРЕВІРКА ГЛИБОКОГО КОПІЮВАННЯ ---");
        bool isDeepCopy = !ReferenceEquals(grandParent, clonedFamily);
        Console.WriteLine($"Чи різні це об'єкти (ReferenceEquals): {isDeepCopy}");
    }
}