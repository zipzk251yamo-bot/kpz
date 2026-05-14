namespace VideoProvider;
public class MobileApp {
    public ISubscription CreateFromApp(string type) {
        Console.WriteLine("Оформлення через мобільний додаток...");
        return type.ToLower() switch {
            "domestic" => new DomesticSubscription(),
            "educational" => new EducationalSubscription(),
            "premium" => new PremiumSubscription(),
            _ => throw new Exception("Невірний вибір у додатку")
        };
    }
}

