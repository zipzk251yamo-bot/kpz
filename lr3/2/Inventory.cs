namespace RPGGame.Decorator
{
    // BaseDecorator: Базовий декоратор для екіпірування
    public abstract class InventoryDecorator : IHero
    {
        protected IHero _hero;

        public InventoryDecorator(IHero hero)
        {
            this._hero = hero;
        }

        public virtual string GetDescription()
        {
            return _hero.GetDescription();
        }

        public virtual int GetAttack()
        {
            return _hero.GetAttack();
        }

        public virtual int GetDefense()
        {
            return _hero.GetDefense();
        }
    }

    // ConcreteDecorator: Зброя (Збільшує атаку)
    public class Weapon : InventoryDecorator
    {
        private string _weaponName;
        private int _attackBonus;

        public Weapon(IHero hero, string weaponName, int attackBonus) : base(hero)
        {
            _weaponName = weaponName;
            _attackBonus = attackBonus;
        }

        public override string GetDescription() => $"{base.GetDescription()} + [{_weaponName}]";
        public override int GetAttack() => base.GetAttack() + _attackBonus;
    }

    // ConcreteDecorator: Одяг/Броня (Збільшує захист)
    public class Clothing : InventoryDecorator
    {
        private string _clothingName;
        private int _defenseBonus;

        public Clothing(IHero hero, string clothingName, int defenseBonus) : base(hero)
        {
            _clothingName = clothingName;
            _defenseBonus = defenseBonus;
        }

        public override string GetDescription() => $"{base.GetDescription()} + [{_clothingName}]";
        public override int GetDefense() => base.GetDefense() + _defenseBonus;
    }

    // ConcreteDecorator: Артефакт (Збільшує і атаку, і захист)
    public class Artifact : InventoryDecorator
    {
        private string _artifactName;
        private int _attackBonus;
        private int _defenseBonus;

        public Artifact(IHero hero, string artifactName, int attackBonus, int defenseBonus) : base(hero)
        {
            _artifactName = artifactName;
            _attackBonus = attackBonus;
            _defenseBonus = defenseBonus;
        }

        public override string GetDescription() => $"{base.GetDescription()} + [{_artifactName}]";
        public override int GetAttack() => base.GetAttack() + _attackBonus;
        public override int GetDefense() => base.GetDefense() + _defenseBonus;
    }
}