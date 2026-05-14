using System;

namespace DesignPatterns.ChainOfResponsibility
{
    public class BillingHandler : BaseHandler
    {
        public override bool Handle()
        {
            Console.WriteLine("\nРівень 1: Ваше звернення стосується фінансів, балансу або поповнення рахунку? (1 - Так, 2 - Ні)");
            Console.Write("Ваш вибір: ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine("[Фінансовий відділ]: Ваш поточний баланс становить 150 грн. Дякуємо за звернення!");
                return true; // Проблему вирішено, виходимо з ланцюжка
            }
            else
            {
                return base.HandleNext(); // Передаємо відповідальність наступному обробнику
            }
        }
    }
}