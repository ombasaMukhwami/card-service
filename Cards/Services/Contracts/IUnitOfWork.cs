namespace Cards.Services.Contracts;

public interface IUnitOfWork: IDisposable
{
    ICardRepository Cards { get; }
    IAppUserRepository Users { get; }
    Task<int> CommitAsync();
}