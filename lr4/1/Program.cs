using System;
using DesignPatterns.ChainOfResponsibility;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== Ласкаво просимо до служби підтримки клієнтів ===");

        // 1. Створюємо об'єкти обробників (4 рівні)
        BaseHandler billing = new BillingHandler();
        BaseHandler tech = new TechSupportHandler();
        BaseHandler tariff = new TariffHandler();
        BaseHandler operatorSupport = new HumanOperatorHandler();

        // 2. Зв'язуємо їх у ланцюжок: Billing -> Tech -> Tariff -> Operator
        billing.SetNextHandler(tech)
               .SetNextHandler(tariff)
               .SetNextHandler(operatorSupport);

        // 3. Запускаємо систему з умовою повторення
        bool isResolved = false;

        // Цикл буде працювати, доки один із обробників не поверне true
        while (!isResolved)
        {
            Console.WriteLine("\n--- Пошук рішення вашого питання ---");
            
            // Викликаємо початок ланцюжка
            isResolved = billing.Handle();
        }

        Console.WriteLine("\nРоботу системи підтримки завершено. Натисніть будь-яку клавішу...");
        Console.ReadKey();
    }
}