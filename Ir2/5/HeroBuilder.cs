namespace Hero;

public class Character 
{
    public string Name { get; set; } = "";

    public int Level { get; set; } = 1;
    public int Age { get; set; } = 0;
    public string HairColor { get; set; } = "";
    public string Department { get; set; } = "";// до якої "гільдії" належить персонаж
    public string BestAchivment { get; set; } = "";
    public List<string> Inventory { get; set; } = new();
    public List<string> History { get; set; } = new();
    public bool IsEvil { get; set; }

    public override string ToString() 
    {
        string role = IsEvil ? "Ворог" : "Наш козак";
        return $"{role}: {Name}\n" +
               $"Рівень: {Level}, Вік: {Age} років\n" +
               $"Факультет: {Department}\n" +
               $"Інвентар: [{string.Join(", ", Inventory)}]\n" +
               $"Найбільше досягнення в житі: {BestAchivment}\n" +
               $"Історія діянь: {string.Join(" | ", History)}\n";
    }
}

public class HeroBuilder : ICharacterBuilder 
{
    private Character _char = new Character { IsEvil = false };

    public ICharacterBuilder SetName(string name) 
    {
        _char.Name = name;
        return this;
    }

    public ICharacterBuilder SetLevel(int level) 
    {
        _char.Level = level;
        return this;
    }

    public ICharacterBuilder SetAge(int age) 
    {
        _char.Age = age;
        return this;
    }
    public ICharacterBuilder SetAppearance(string hair) 
    {
        _char.HairColor = hair;
        return this;
    }
    public ICharacterBuilder AddInventoryItem(string item) 
    {
        _char.Inventory.Add(item);
        return this;
    }
    public ICharacterBuilder AddHistory(string history) 
    {
        _char.History.Add(history);
        return this;
    }
    public ICharacterBuilder SetDepartment(string department) 
    {
        _char.Department = department;
        return this;
    }
    public ICharacterBuilder SetBestAchivment(string achivment) 
    {
        _char.BestAchivment = achivment;
        return this;
    }
    

    public Character Build() => _char;
}

public class EnemyBuilder : ICharacterBuilder 
{
    private Character _char = new Character { IsEvil = true };

    public ICharacterBuilder SetName(string name) 
    {
        _char.Name = name;
        return this;
    }
    
        public ICharacterBuilder SetLevel(int level) 
    {
        _char.Level = level;
        return this;
    }

    public ICharacterBuilder SetAge(int age) 
    {
        _char.Age = age;
        return this;
    }
    public ICharacterBuilder SetAppearance(string hair) 
    {
        _char.HairColor = hair;
        return this;
    }
    public ICharacterBuilder AddInventoryItem(string item) 
    {
        _char.Inventory.Add(item);
        return this;
    }
    public ICharacterBuilder AddHistory(string history) 
    {
        _char.History.Add(history);
        return this;
    }
    public ICharacterBuilder SetDepartment(string department) 
    {
        _char.Department = department;
        return this;
    }
     public ICharacterBuilder SetBestAchivment(string achivment) 
    {
        _char.BestAchivment = achivment;
        return this;
    }

 public Character Build() => _char;
}