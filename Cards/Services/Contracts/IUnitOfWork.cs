namespace Cards.Services.Contracts;

public interface IUnitOfWork: IDisposable
{
    ICardRepository Vehicles { get; }
    Task<int> CommitAsync();
    CardDbContext _dbContext { get; }
}