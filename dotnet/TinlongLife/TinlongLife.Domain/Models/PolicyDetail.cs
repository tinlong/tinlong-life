namespace TinlongLife.Domain.Models;

public abstract class PolicyDetail
{
    public Guid Id { get; set; }
    public Guid PolicyId { get; set; }
    public Policy Policy { get; set; }
    public decimal FaceAmount { get; set; }
    public string ContractState { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}