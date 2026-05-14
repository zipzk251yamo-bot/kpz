using System;

namespace DesignPatterns.ChainOfResponsibility
{
    public class TechSupportHandler : BaseHandler
    {
        public override bool Handle()
        {
            Console.WriteLine("\nРівень 2: У вас виникли технічні проблеми з інтернетом чи зв'язком? (1 - Так, 2 - Ні)");
            Console.Write("Ваш вибір: ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine("[Технічна підтримка]: Ми оновили ваші мережеві налаштування. Перезавантажте пристрій. До побачення!");
                return true; 
            }
            else
            {
                return base.HandleNext(); 
            }
        }
    }
}