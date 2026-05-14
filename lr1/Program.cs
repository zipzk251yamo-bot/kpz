// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("\nРозширення для класу String");
string s = "abcdeffg";
Console.WriteLine("Рядок: "+ s);
Console.WriteLine("Кількість 'f': "+ s.WordCount('f'));
Console.WriteLine("Інвертованйи рядок: "+ s.Invert());

Console.WriteLine("Розширення для одновимірного массиву");
int[] mas = [1, 2, 3, 4, 5, 6, 7,7,7];
string[] str = ["Раз", "Два","Раз","Три", "Два"];
Console.Write("Масив з int: "  ); mas.Print();
Console.Write("Масив з sting: "); str.Print();

Console.WriteLine("Кількість цифр 7 : " + mas.Search<int>(7));
Console.WriteLine("Кількість 'Два': " + str.Search<string>("Два"));

Console.WriteLine("Масив int із унікальними елементами: "); 
int[] newMas = mas.GetUnique();
newMas.Print();
Console.WriteLine("Масив string із унікальними елементами: " );
string[] newStr = str.GetUnique();
newStr.Print();

Console.WriteLine("----------------");

Console.WriteLine("\nДодаємо студетів...");
var students_ipz = new ExtendedDictionary<int, string, string>(); ///створили список групи ІПЗ

//Додаємо студентів до групи
//ID, ПІБ, Група
students_ipz.Add(1, "Чернюк М.В.", "ЗІПЗк-25-1");
students_ipz.Add(2, "Іванчук В.М.", "ЗІПЗк-25-1");
students_ipz.Add(3, "Шевчук О.В.", "ЗІПЗк-25-1");
students_ipz.Add(4, "Ященко М.О.", "ЗІПЗк-25-1");
Console.WriteLine($"\nВсього студентів у словнику ЗІПЗк: {students_ipz.Count}");

var students_kn = new ExtendedDictionary<int, string, string>(); ///створили список групи KN

//Додаємо студентів до групи
//ID, ПІБ, Група
students_kn.Add(1, "Порошенко В.І.", "КН-25-1");
students_kn.Add(2, "Кібець А.В.", "КН-25-1");
students_kn.Add(3, "Кущ О.І", "КН-25-1");
Console.WriteLine($"\nВсього студентів у словнику Кн: {students_kn.Count}");

//створюємо словник усіх груп
var groups = new ExtendedDictionary<string, string, ExtendedDictionary<int, string, string>>();

Console.WriteLine("----------------");

//Назва групи, факультет, словник студентів
groups.Add("ЗІПЗк-25-1", "ФІКТ", students_ipz);
groups.Add("Кн-25-1", "ФІКТ", students_kn);


Console.WriteLine("Отримуємо дані студента з id=4");
var Yashchenko = students_ipz[4];///Отримуємо дані студента з id=4
Console.WriteLine($"Дані: ID: {Yashchenko.Key}  ПІБ:{Yashchenko.Value1}  Група: {Yashchenko.Value2}");


Console.WriteLine("\n----------------");
Console.WriteLine("Дані всіх груп і студентів в них");
foreach (var group in groups)///виводимо дані всіх груп і студентів в них
    foreach (var student in group.Value2)
    {
        Console.WriteLine($"Знайдено:{group.Key}  {group.Value1} ({student.Value1})");
    }

Console.WriteLine("\n----------------");
Console.WriteLine("Видаляємо групу Кн-25-1");
groups.Remove("Кн-25-1");//Видаляємо одну групу

foreach (var group in groups)///виводимо дані всіх груп і студентів в них
    foreach (var student in group.Value2)
    {
        Console.WriteLine($"Знайдено:{group.Key}  {group.Value1} ({student.Value1})");
    }

Console.WriteLine("\n----------------");
Console.WriteLine($"Чи є група з ЗІПЗк-25-1? {groups.ContainsKey("ІПЗк-25-1")} ");
Console.WriteLine($"Чи є група з КН-25-1? {groups.ContainsKey("КН-25-1")} ");
Console.WriteLine($"Чи є групі ЗІПЗк-25-1 студент Ященко М.О.? {students_ipz.ContainsValues("Ященко М.О.", "ЗІПЗк-25-1")} ");
Console.WriteLine($"Чи є групі ЗІПЗк-25-1 студент Ковальчук А.Н.? {students_ipz.ContainsValues("Ковальчук А.Н", "ЗІПЗк-25-1")} ");
Console.WriteLine("\n----------------");

