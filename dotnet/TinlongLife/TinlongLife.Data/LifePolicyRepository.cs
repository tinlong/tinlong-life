using Microsoft.EntityFrameworkCore;
using TinlongLife.Domain.Interfaces;
using TinlongLife.Domain.Models;

namespace TinlongLife.Data;

public class LifePolicyRepository : IRepository<LifePolicy>
{
    private TinlongLifeDbContext _context;
    
    public LifePolicyRepository(TinlongLifeDbContext context)
    {
        _context = context;
    }
    
    public async Task<LifePolicy> GetById(Guid id)
    {
        return await _context.LifePolicies.FindAsync(id);
    }

    public IEnumerable<LifePolicy> GetAll()
    {
        return _context.LifePolicies;
    }

    public async Task<Guid?> Add(LifePolicy entity)
    {
        await _context.LifePolicies.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task Update(LifePolicy entity)
    {
        _context.LifePolicies.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(LifePolicy entity)
    {
        _context.LifePolicies.Remove(entity);
        await _context.SaveChangesAsync();
    }
}