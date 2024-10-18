using AzureADAuthentication.API.Arguments;
using AzureADAuthentication.API.Entities;
using System.Linq.Expressions;

namespace AzureADAuthentication.API.Interfaces.Repositories;

public interface IUserRepository
{
    Task CreateAsync(User user);
    Task<User?> GetByPredicateAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken);
    Task<bool> LoginAsync(LoginArgument loginArgument);
    Task<bool> UserNameExistsAsync(string userName, CancellationToken cancellationToken);
}
