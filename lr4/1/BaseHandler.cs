using System;

namespace DesignPatterns.ChainOfResponsibility
{
    public abstract class BaseHandler
    {
        private BaseHandler _next;

        public BaseHandler SetNextHandler(BaseHandler next)
        {
            this._next = next;
            // Повертаємо next для можливості зручного зв'язування (Fluent Interface)
            return next;
        }

        // Змінено на bool: повертає true, якщо питання вирішено, і false, якщо треба повторити меню
        public abstract bool Handle();

        protected bool HandleNext()
        {
            if (this._next == null)
            {
                Console.WriteLine("\n[Система]: Жоден з рівнів підтримки не зміг розпізнати вашу проблему.");
                Console.WriteLine("Повертаємось на головне меню...\n");
                return false; // Досягнуто кінця ланцюжка, меню повториться
            }
            else 
            {
                return this._next.Handle(); // Передаємо запит далі
            }
        }
    }
}