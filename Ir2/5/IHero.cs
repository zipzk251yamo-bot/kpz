namespace Hero;

public interface ICharacterBuilder 
{
    ICharacterBuilder SetName(string name);
    ICharacterBuilder SetLevel(int level);
    ICharacterBuilder SetAge(int age);
    ICharacterBuilder SetBestAchivment(string achivment);
    ICharacterBuilder SetAppearance(string hair);
    ICharacterBuilder AddInventoryItem(string item);

    ICharacterBuilder AddHistory(string history); 
    ICharacterBuilder SetDepartment(string department);
    Character Build();
}