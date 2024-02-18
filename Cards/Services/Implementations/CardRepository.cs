using Cards.Models;
using Cards.Services.Contracts;

namespace Cards.Services.Implementations;

public class CardRepository : Repository<Card>, ICardRepository
{
    public CardRepository(CardDbContext dbContext) : base(dbContext)
    {
    }

    public Task<IEnumerable<Card>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Card>> SearchAllAsync(Card card)
    {
        throw new NotImplementedException();
    }
}