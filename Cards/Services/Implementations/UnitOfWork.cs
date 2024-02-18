using Cards.Services.Contracts;

namespace Cards.Services.Implementations;

public sealed class UnitOfWork : IUnitOfWork
{
    private bool _disposed;
    private ILogger _logger;
    private readonly CardDbContext _dbContext;
    public UnitOfWork(ILoggerFactory logger, CardDbContext dbContext)
    {
        _logger = logger.CreateLogger("logs");
        _dbContext = dbContext;
    }
    private ICardRepository _cards;
    private IAppUserRepository _users;
    public ICardRepository Cards => _cards?? new CardRepository(_dbContext);
    public IAppUserRepository Users => _users?? new AppUserRepository(_dbContext);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    public void Dispose(bool disposing)
    {
        try
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
    public async Task<int> CommitAsync()
    => await _dbContext.SaveChangesAsync();
}