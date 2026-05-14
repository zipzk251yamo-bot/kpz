namespace VideoProvider;
public class ManagerCall {
    public ISubscription OrderManager(string clientStatus) {
        Console.WriteLine("Менеджер підбирає підписку за статусом клієнта...");
        // Власна логіка: менеджери пропонують Premium для VIP
        if (clientStatus == "VIP") return new PremiumSubscription();
        if (clientStatus == "Student") return new EducationalSubscription();
        return new DomesticSubscription();
    }
} 

