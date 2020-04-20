using System.Collections.Generic;
using System.Threading.Tasks;
using Celo.Service.Models.ServiceModels;

namespace Celo.Service.RandomUser.Service
{
    public class UserService : IUserService
    {
        public Task<bool> DeleteUser()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<UserResponse>> GetUser()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateUser()
        {
            throw new System.NotImplementedException();
        }
    }
}