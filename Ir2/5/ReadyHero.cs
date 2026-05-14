namespace Hero;

public class GameDirector
{
    public void ConstructMe(ICharacterBuilder builder)
    {
        builder.SetName("Богдан Федорчук")
               .SetLevel(99)
               .SetAge(20)
               .SetAppearance("Горіхове")
               .AddInventoryItem("Ноутбук")
                .AddInventoryItem("Козацька люлька")
                .AddInventoryItem("Кінь чорнобровий")
                .SetDepartment("IПЗ")
               .SetBestAchivment("Закінчив коледж")
               .AddHistory("Поступив в коледж")
               .AddHistory("Працює в коледжі")
               .AddHistory("Закінчив коледж")
               .AddHistory("Поступив в політех")
               .AddHistory("Працює в політеху");
    }

    public void ConstructF1(ICharacterBuilder builder)
    {
        builder.SetName("Макс Ферстапенн")
                .SetLevel(45)
                .SetAge(27)
                .SetAppearance("Чорне")
                .AddInventoryItem("RedBull RB26")
                .AddInventoryItem("Winston Red")
                .AddInventoryItem("Живчик")
                .SetDepartment("Redbull")
                .AddHistory("Виграв Монако 2024 року")
                .SetBestAchivment("3-кратний чемпіон світу F1")
                .AddHistory("Не був в Бердичеві");
    }



}
