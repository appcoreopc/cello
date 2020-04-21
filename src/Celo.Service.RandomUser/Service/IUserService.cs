using System.Collections.Generic;
using System.Threading.Tasks;
using Celo.Service.Models.ServiceModels;
using Celo.Service.Models.ServiceModels.Request;

namespace Celo.Service.RandomUser.Service
{
    public interface IUserService
    {
        Task<IEnumerable<UsersDetails>> GetUserAsync(UserGetRequest request);

        Task<DataOperationStatus> UpdateUserAsync(UserUpdateRequest request);

        Task<DataOperationStatus> DeleteUserAsync(int request);

    }
}
