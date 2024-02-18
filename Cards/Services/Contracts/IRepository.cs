namespace Cards.Services.Contracts;

public interface IRepository<T> where T : class
{
    Task<T?> GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
