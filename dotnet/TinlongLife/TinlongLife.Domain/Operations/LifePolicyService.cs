using TinlongLife.Domain.Interfaces;
using TinlongLife.Domain.Models;

namespace TinlongLife.Domain.Operations;

public class LifePolicyService(IRepository<LifePolicy> Repository)
{
    public async Task<LifePolicy> GetById(Guid id)
    {
        return await Repository.GetById(id);
    }

    public IEnumerable<LifePolicy> GetAll()
    {
        return Repository.GetAll();
    }

    public async Task<Guid?> AddNewPolicy(
        decimal faceAmount,
        string contractState,
        DateTime billingStartDate,
        BillingFrequencyOption frequency,
        decimal billingAmount)
    {
        string policyNumber = Policy.NewPolicyNumber();
        return await AddNewPolicyWithPolicyNumber(policyNumber, faceAmount, contractState, billingStartDate, frequency, billingAmount);
    }

    public async Task<Guid?> AddNewPolicyWithPolicyNumber(string policyNumber,
        decimal faceAmount,
        string contractState,
        DateTime billingStartDate,
        BillingFrequencyOption frequency,
        decimal billingAmount)
    {
        LifePolicy policy = new LifePolicy
        {
            PolicyNumber = policyNumber
        };
        policy.PolicyDetail = new LifePolicyDetail
        {
            ContractState = contractState,
            FaceAmount = faceAmount,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Policy = policy
        };
        policy.BillingDetail = new LifeBillingDetail
        {
            Frequency = frequency,
            Amount = billingAmount,
            BillingStartDate = billingStartDate,
            NextBillingDate = frequency switch
            {
                BillingFrequencyOption.Monthly => billingStartDate.AddMonths(1),
                BillingFrequencyOption.Quarterly => billingStartDate.AddMonths(3),
                BillingFrequencyOption.SemiAnnual  => billingStartDate.AddMonths(6),
                _ => billingStartDate.AddYears(1)
            },
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Policy = policy
        };
        
        await Repository.Add(policy);
        return policy.Id;
    }
}