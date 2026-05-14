
using Hero;
Console.OutputEncoding = System.Text.Encoding.UTF8;
GameDirector director = new GameDirector();

// Створюємо Героя
var heroBuilder = new HeroBuilder();
director.ConstructMe(heroBuilder);
Character myHero = heroBuilder.Build();

// Створюємо Ворога
var enemyBuilder = new EnemyBuilder();
director.ConstructF1(enemyBuilder);
Character myEnemy = enemyBuilder.Build();

Console.WriteLine("=== ПЕРСОНАЖІ ===");
Console.WriteLine(myHero);
Console.WriteLine(myEnemy);