using System;

namespace RPGGame.Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Створення Воїна ===");
            IHero myWarrior = new Warrior();
            PrintHeroStats(myWarrior);

            Console.WriteLine("\n=== Воїн знаходить Меч та Щит ===");
            // Нашаровуємо декоратори один на одний
            myWarrior = new Weapon(myWarrior, "Сталевий Меч", 10);
            myWarrior = new Clothing(myWarrior, "Дерев'яний Щит", 5);
            PrintHeroStats(myWarrior);

            Console.WriteLine("\n=== Воїн знаходить Епічний Артефакт ===");
            // Додаємо ще один шар інвентарю
            myWarrior = new Artifact(myWarrior, "Перстень Сили", 15, 10);
            PrintHeroStats(myWarrior);

            Console.WriteLine("\n-----------------------------------\n");

            Console.WriteLine("=== Створення Мага з повним екіпіруванням відразу ===");
            IHero myMage = new Artifact(
                             new Clothing(
                               new Weapon(new Mage(), "Посох Вогню", 25), 
                             "Мантія Невидимості", 8), 
                           "Амулет Мудрості", 5, 5);
            PrintHeroStats(myMage);

            Console.ReadKey();
        }

        static void PrintHeroStats(IHero hero)
        {
            Console.WriteLine($"Герой: {hero.GetDescription()}");
            Console.WriteLine($"Атака: {hero.GetAttack()} | Захист: {hero.GetDefense()}");
        }
    }
}