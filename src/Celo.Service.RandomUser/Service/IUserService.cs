using System.Collections.Generic;
using System.Threading.Tasks;
using Celo.Service.Models.ServiceModels;

namespace Celo.Service.RandomUser.Service
{
    interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetUser();

        Task<bool> UpdateUser();

        Task<bool> DeleteUser();

    }

}
