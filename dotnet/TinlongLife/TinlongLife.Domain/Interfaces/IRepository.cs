namespace TinlongLife.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> GetById(Guid id);
    IEnumerable<T> GetAll();
    Task<Guid?> Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}