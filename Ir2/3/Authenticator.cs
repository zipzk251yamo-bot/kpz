namespace DesignPatterns.Singleton
{
    // sealed запобігає створенню похідних класів
    sealed class Authenticator
    {
        private static Authenticator? _instance;
        private static readonly object _lockObj = new object(); // Об'єкт для блокування потоків

        // Приватний конструктор: ніхто не зможе викликати зовні
        private Authenticator()
        {
            Console.WriteLine("Клас Authenticator ініціалізовано.");
        }

        public static Authenticator GetInstance()
        {
            // Перша перевірка без блокування для продуктивності
            if (_instance == null)
            {
                lock (Authenticator._lockObj)
                {
                    // Друга перевірка всередині блокування
                    if (_instance == null)
                    {
                        _instance = new Authenticator();
                    }
                }
            }
            return _instance;
        }

        public void LogIn(string username)
        {
            Console.WriteLine($"Користувач {username} увійшов у систему.");
        }
    }
}