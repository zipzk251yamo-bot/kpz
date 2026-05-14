using System;
using DesignPatterns.Mediator;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // 1. Створюємо диспетчерський центр 
        CommandCentre commandCentre = new CommandCentre();

        // 2. Створюємо смуги і відразу підключаємо їх до центру
        Runway runway1 = new Runway(commandCentre);
        Runway runway2 = new Runway(commandCentre);
        commandCentre.RegisterRunway(runway1);
        commandCentre.RegisterRunway(runway2);

        // 3. Створюємо літаки
        Aircraft aircraft1 = new Aircraft("Boeing-747", commandCentre);
        Aircraft aircraft2 = new Aircraft("Airbus-A320", commandCentre);
        Aircraft aircraft3 = new Aircraft("Cessna-172", commandCentre);

        commandCentre.RegisterAircraft(aircraft1);
        commandCentre.RegisterAircraft(aircraft2);
        commandCentre.RegisterAircraft(aircraft3);

        Console.WriteLine("=== Командний центр ===");

        // Спроба посадити перший літак 
        // Має бути успішно
        aircraft1.Land();

        // Спроба посадити другий літак 
        //  успішно, є ще 1 смуга
        aircraft2.Land();

        // Спроба посадити третій літак 
        //  відмова, смуг немає
        aircraft3.Land();

        // Перший літак злітає 
        // звільняє смугу
        aircraft1.TakeOff();

        // Третій літак знову просить посадку 
        // Тепер має бути успішно
        aircraft3.Land();

       // Console.ReadLine();
    }
}