using Cards.Models;
using System.Security.Claims;

namespace Cards.Services.Contracts;

public interface IUnitOfWork: IDisposable
{
    ICardRepository Cards { get; }
    IAppUserRepository Users { get; }
    Task<int> CommitAsync();
}

public interface ICurrentUser
{
    string? Name { get; }
    int GetUserId();
    AppUser GetUser();
    string? GetUserEmail();
    bool IsAuthenticated();
    bool IsInRole(string role);
}