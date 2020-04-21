using System.Collections.Generic;
using System.Threading.Tasks;
using Celo.Data.InMemory;
using Celo.Service.Models.ServiceModels.Request;

namespace Celo.Service.RandomUser.Service
{
    public interface IUserDataProvider
    {
        Task<IEnumerable<User>> GetUserAsync(UserGetRequest user);

        Task<DataOperationStatus> UpdateUserAsync(UserUpdateRequest user);

        Task<DataOperationStatus> DeleteUserAsync(int user);

        Task CreateUserAsync(User user);

    }
}