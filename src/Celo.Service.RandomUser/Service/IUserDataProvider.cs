using System.Collections.Generic;
using System.Threading.Tasks;
using Celo.Data.InMemory;

namespace Celo.Service.RandomUser.Service
{
    public interface IUserDataProvider
    {
        Task<IEnumerable<User>> GetUserAsync();

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(User user);

    }
}