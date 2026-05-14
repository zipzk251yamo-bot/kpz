namespace VideoProvider;
public class DomesticSubscription : ISubscription {
    public int MonthlyPrice => 120;
    public int MinPeriodDay => 30;
    public List<string> Channels => new List<string> { "Кіно", "Новини" };
    public string GetDetails() => $"Домашня: {MonthlyPrice}грн, {MinPeriodDay} днів. Канали: {string.Join(", ", Channels)}";
}

public class EducationalSubscription : ISubscription {
    public int MonthlyPrice => 80;
    public int MinPeriodDay => 14;
    public List<string> Channels => new List<string> { "Наука", "Discovery" };
    public string GetDetails() => $"Освітня: {MonthlyPrice}грн, {MinPeriodDay} днів. Канали: {string.Join(", ", Channels)}";
}

public class PremiumSubscription : ISubscription {
    public int MonthlyPrice => 300;
    public int MinPeriodDay => 7;
    public List<string> Channels => new List<string> { "Всі канали", "4K", "Спорт" };
    public string GetDetails() => $"Преміум: {MonthlyPrice}грн, {MinPeriodDay} днів. Канали: {string.Join(", ", Channels)}";
}