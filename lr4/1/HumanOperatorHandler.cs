using System;

namespace DesignPatterns.ChainOfResponsibility
{
    public class HumanOperatorHandler : BaseHandler
    {
        public override bool Handle()
        {
            Console.WriteLine("\nРівень 4: Бажаєте з'єднатися з живим оператором? (1 - Так, 2 - Ні)");
            Console.Write("Ваш вибір: ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine("[Оператор]: З'єднуємо з оператором... Зачекайте на лінії. Дякуємо!");
                return true; 
            }
            else
            {
                return base.HandleNext(); 
            }
        }
    }
}