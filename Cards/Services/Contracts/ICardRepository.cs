using Cards.Models;

namespace Cards.Services.Contracts;

public interface ICardRepository : IRepository<Card>
{
    Task<IEnumerable<Card>> GetAllAsync();
    Task<IEnumerable<Card>> SearchAllAsync(Card card);
}
