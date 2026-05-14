using System;

namespace DesignPatterns.ChainOfResponsibility
{
    public class TariffHandler : BaseHandler
    {
        public override bool Handle()
        {
            Console.WriteLine("\nРівень 3: Ви бажаєте змінити свій тарифний план або підключити нові послуги? (1 - Так, 2 - Ні)");
            Console.Write("Ваш вибір: ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine("[Відділ тарифів]: Вам надіслано SMS з доступними тарифами для підключення. Дякуємо!");
                return true; 
            }
            else
            {
                return base.HandleNext(); 
            }
        }
    }
}