using Cards.Models;

namespace Cards.Services.Contracts;

public interface ICardRepository : IRepository<Card>
{
    Task<IEnumerable<Card>> GetAllAsync(int? userId);
    Task<IEnumerable<Card>> SearchAllAsync(Card card);
}
