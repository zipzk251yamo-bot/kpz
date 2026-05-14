namespace VideoProvider;
public class WebSite {
    public ISubscription PurchaseSubscription(string type) {
        // Проста логіка створення (Simple Factory style)
        if (type.ToLower() == "domestic") return new DomesticSubscription();
        if (type.ToLower() == "educational") return new EducationalSubscription();
        if (type.ToLower() == "premium") return new PremiumSubscription();
        throw new Exception("Тип не знайдено на сайті");
    }
}

