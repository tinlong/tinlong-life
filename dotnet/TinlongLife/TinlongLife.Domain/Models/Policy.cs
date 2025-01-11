namespace TinlongLife.Domain.Models;

public abstract class Policy
{
    public Guid Id { get; set; }
    public string PolicyNumber { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public PolicyDetail PolicyDetail { get; set; }
    public BillingDetail BillingDetail { get; set; }
    
    public static string NewPolicyNumber() => new Random().Next(1, int.MaxValue).ToString("0000000000");
}