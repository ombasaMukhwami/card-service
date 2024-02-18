using Cards.Models;

namespace Cards.Services.Contracts;

public interface IAppUserRepository : IRepository<AppUser>
{
    Task<AppUser?> GetUserByEmailAsync(string email);
}
