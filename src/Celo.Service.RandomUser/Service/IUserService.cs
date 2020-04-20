using System.Collections.Generic;
using System.Threading.Tasks;
using Celo.Service.Models.ServiceModels;
using Celo.Service.Models.ServiceModels.Request;

namespace Celo.Service.RandomUser.Service
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetUserAsync(UserRequest request);

        Task<bool> UpdateUserAsync();

        Task<bool> DeleteUserAsync();

    }
}
