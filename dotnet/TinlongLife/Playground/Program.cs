using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TinlongLife.Data;
using TinlongLife.Domain.Interfaces;
using TinlongLife.Domain.Models;
using TinlongLife.Domain.Operations;

namespace Playground;

class Program
{
    static void Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        var connString = builder.Configuration.GetConnectionString("TinlongLifeDatabase");
        builder.Services.AddDbContext<TinlongLifeDbContext>(options => options.UseSqlServer(connString));
        builder.Services.AddSingleton<IRepository<LifePolicy>, LifePolicyRepository>();
        builder.Services.AddSingleton<LifePolicyService>();
        
        var serviceProvider = builder.Services.BuildServiceProvider();
        
        var service = serviceProvider.GetRequiredService<LifePolicyService>();
        
        var policyId = service.AddNewPolicy(1000, "Active", DateTime.Now, BillingFrequencyOption.Monthly, 100);
        
        var policy = service.GetById(policyId.Value);

        var stuff = "stuff";
    }
}