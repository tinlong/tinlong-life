namespace TinlongLife.Domain.Models;

public enum BillingFrequencyOption
{
    Monthly = 12,
    Quarterly = 4,
    SemiAnnual = 2,
    Annual = 1,
}

public abstract class BillingDetail
{
    public Guid Id { get; set; }
    public Guid PolicyId { get; set; }
    public Policy Policy { get; set; }
    public BillingFrequencyOption Frequency { get; set; }
    public DateTime BillingStartDate { get; set; }
    public DateTime NextBillingDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public decimal Amount { get; set; }
    public decimal AnnualizedAmount => Amount * (int)Frequency;
}