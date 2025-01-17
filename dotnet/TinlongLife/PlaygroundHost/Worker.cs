using TinlongLife.Domain.Models;
using TinlongLife.Domain.Operations;

namespace PlaygroundHost;

public class Worker(
	IServiceScopeFactory serviceScopeFactory,
	ILogger<Worker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
		await using var scope = serviceScopeFactory.CreateAsyncScope();

		var service = scope.ServiceProvider.GetRequiredService<LifePolicyService>();

	    LogInfo("Worker running at: {time}", DateTimeOffset.Now);

	    var policyId = await service.AddNewPolicy(1000, "Active", DateTime.Now, BillingFrequencyOption.Monthly, 100);

	    LogInfo("Added Life Policy: {id}", policyId);

	    var policy = await service.GetById(policyId.Value);

	    LogInfo("Got Life Policy: {id} with Policy Number: {policyNumber}", policy.Id, policy.PolicyNumber);
	}

	private void LogInfo(string message, params object?[] args)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(message, args);
        }
    }
}
