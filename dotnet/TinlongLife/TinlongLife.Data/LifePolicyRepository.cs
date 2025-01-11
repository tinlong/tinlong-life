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
    
    public LifePolicy GetById(Guid id)
    {
        return _context.LifePolicies.Find(id);
    }

    public IEnumerable<LifePolicy> GetAll()
    {
        return _context.LifePolicies;
    }

    public Guid? Add(LifePolicy entity)
    {
        _context.LifePolicies.Add(entity);
        _context.SaveChanges();
        return entity.Id;
    }

    public void Update(LifePolicy entity)
    {
        _context.LifePolicies.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(LifePolicy entity)
    {
        _context.LifePolicies.Remove(entity);
        _context.SaveChanges();
    }
}