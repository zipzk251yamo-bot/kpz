using System;

namespace RPGGame.Decorator
{
    // IWrappee: Базовий інтерфейс компонента
    public interface IHero
    {
        string GetDescription();
        int GetAttack();
        int GetDefense();
    }

    // ConcreteWrappee: Конкретний герой (Воїн)
    public class Warrior : IHero
    {
        public string GetDescription() => "Воїн";
        public int GetAttack() => 15;
        public int GetDefense() => 10;
    }

    // ConcreteWrappee: Конкретний герой (Маг)
    public class Mage : IHero
    {
        public string GetDescription() => "Маг";
        public int GetAttack() => 20;
        public int GetDefense() => 5;
    }

    // ConcreteWrappee: Конкретний герой (Паладін)
    public class Paladin : IHero
    {
        public string GetDescription() => "Паладін";
        public int GetAttack() => 12;
        public int GetDefense() => 15;
    }
}