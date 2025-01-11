namespace TinlongLife.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    T GetById(Guid id);
    IEnumerable<T> GetAll();
    Guid? Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}