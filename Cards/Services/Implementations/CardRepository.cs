using Cards.Models;
using Cards.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Cards.Services.Implementations;

public class CardRepository : Repository<Card>, ICardRepository
{
    public CardRepository(CardDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Card>> GetAllAsync(int? userId) =>
        userId == null ? await Db.Cards.AsNoTracking().ToListAsync() :
        await Db.Cards.Where(c => c.UserId == userId).AsNoTracking().ToListAsync();


    public Task<IEnumerable<Card>> SearchAllAsync(Card card)
    {
        throw new NotImplementedException();
    }
}

public class AppUserRepository : Repository<AppUser>, IAppUserRepository
{
    public AppUserRepository(CardDbContext dbContext) : base(dbContext)
    {
    }
}