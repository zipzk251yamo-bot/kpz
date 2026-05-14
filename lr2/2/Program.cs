
using TechFactory.AbstractFactory;

class Program
{
    static void ProduceTech(ITechFactory factory)
    {
        //Console.WriteLine(factory.GetType().Name + " виробляє:");
        ILaptop laptop = factory.CreateLaptop();
        ISmartphone smartphone = factory.CreateSmartphone();
        try
        {
            IEBook netbook = factory.CreateEBook();
            Console.WriteLine($"Вироблено: {laptop?.Model}, {smartphone?.Model} та {netbook?.Model}");
        }
        catch (NotImplementedException)
        {
            Console.WriteLine($"Вироблено: {laptop?.Model} та {smartphone?.Model}");
        }

    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("--- Лінія IProne ---");
        ProduceTech(new IProneFactory());

        Console.WriteLine("--- Лінія Kiaomi ---");
        ProduceTech(new KiaomiFactory());

        Console.WriteLine("--- Лінія Berdichev ---");
        ProduceTech(new BerdichevFactory());
    }
}