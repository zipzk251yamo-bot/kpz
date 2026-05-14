using System.Text;
namespace LightHTML{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // 6. Створення елемента сторінки (У нашому випадку - маркований список)
            LightElementNode ul = new LightElementNode("ul", true, false);
            ul.AddCssClass("my-list");
            ul.AddCssClass("dark-theme");

            // Створюємо перший пункт списку
            LightElementNode li1 = new LightElementNode("li", true, false);
            li1.AddChild(new LightTextNode("Перший елемент списку"));

            // Створюємо другий пункт списку
            LightElementNode li2 = new LightElementNode("li", true, false);
            li2.AddChild(new LightTextNode("Другий елемент списку"));

            // Створюємо третій пункт списку з одиничним тегом <img> для демонстрації
            LightElementNode li3 = new LightElementNode("li", true, false);
            LightElementNode img = new LightElementNode("img", false, true); // IsSelfClosing = true
            img.AddCssClass("list-icon");
            li3.AddChild(img);
            li3.AddChild(new LightTextNode(" Третій елемент із зображенням"));

            // Додаємо всі <li> у наш <ul>
            ul.AddChild(li1);
            ul.AddChild(li2);
            ul.AddChild(li3);

            // 7. Демонстрація правильної роботи коду
            Console.WriteLine("=== Демонстрація OuterHTML ===");
            Console.WriteLine(ul.OuterHtml());

            Console.WriteLine("\n=== Демонстрація InnerHTML ===");
            Console.WriteLine(ul.InnerHtml());

            Console.WriteLine($"\nКількість дочірніх елементів у списку (ChildCount): {ul.ChildCount}");

            ul.SaveHtmlToFile( "book");

            //Console.ReadKey();
        }
    }
}