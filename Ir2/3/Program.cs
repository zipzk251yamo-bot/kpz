namespace DesignPatterns.Singleton;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Спроба отримати екземпляр з 10 різних потоків:");

        for (int i = 0; i < 10; i++)
        {
            int userId = i;
            Thread t = new Thread(() =>
            {
                Authenticator auth = Authenticator.GetInstance();
                Console.WriteLine($"Потік {userId}: ID об'єкта = {auth.GetHashCode()}");
                auth.LogIn($"User_{userId}");
            });
            t.Start();
        }

        // Дамо час потокам завершити роботу
        Thread.Sleep(1000);

        Console.WriteLine("\n-------------------------------------------");
        Authenticator final1 = Authenticator.GetInstance();
        Authenticator final2 = Authenticator.GetInstance();

        if (ReferenceEquals(final1, final2))
        {
            Console.WriteLine("Перевірка успішна: обидва посилання вказують на один і той самий об'єкт.");
        }
    }
}