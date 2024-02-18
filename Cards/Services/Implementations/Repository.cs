using Cards.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Cards.Services.Implementations;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly CardDbContext Db;
    private readonly DbSet<T> _table;
    public Repository(CardDbContext dbContext)
    {
        Db = dbContext;
        _table = Db.Set<T>();
    }
    public void Add(T entity)
    {
        _table.Add(entity);
    }

    public void Delete(T entity)
    {
        _table.Remove(entity);
    }

    public void Update(T entity)
    {
        _table.Update(entity);
    }
}
