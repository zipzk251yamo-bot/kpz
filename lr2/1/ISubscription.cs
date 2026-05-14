namespace VideoProvider
{
    public interface ISubscription
    {
        int MonthlyPrice { get; }
        int MinPeriodDay { get; }
        List<string> Channels { get; }
        string GetDetails();
    }
}