using System.Configuration;
using Microsoft.EntityFrameworkCore;
using TinlongLife.Domain.Interfaces;
using TinlongLife.Domain.Models;

namespace TinlongLife.Data;

public class TinlongLifeDbContext : DbContext
{
    public TinlongLifeDbContext() { }
    
    public TinlongLifeDbContext(DbContextOptions<TinlongLifeDbContext> options) : base(options)
    {
    }
    public DbSet<Policy> Policies { get; set; }
    public DbSet<PolicyDetail> PolicyDetails { get; set; }
    public DbSet<BillingDetail> BillingDetails { get; set; }

    
    public DbSet<LifePolicy> LifePolicies { get; set; }
    public DbSet<LifePolicyDetail> LifePolicyDetails { get; set; }
    public DbSet<LifeBillingDetail> LifeBillingDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        var connectionString = Environment.GetEnvironmentVariable("MsSqlConnectionString");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ConfigurationErrorsException("Sql server connection string configuration required");
        }
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Policy>()
            .HasIndex(p => p.PolicyNumber)
            .IsUnique();
    }
}