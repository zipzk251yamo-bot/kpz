namespace VideoProvider;
class Program {
    static void Main() {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Через сайт
        var web = new WebSite();
        var sub1 = web.PurchaseSubscription("domestic");
        Console.WriteLine($"Сайт: {sub1.GetDetails()}");

        // Через додаток
        var app = new MobileApp();
        var sub2 = app.CreateFromApp("premium");
        Console.WriteLine($"Додаток: {sub2.GetDetails()}");

        // Через менеджера
        var manager = new ManagerCall();
        var sub3 = manager.OrderManager("Student");
        Console.WriteLine($"Дзвінок: {sub3.GetDetails()}");
    }
}