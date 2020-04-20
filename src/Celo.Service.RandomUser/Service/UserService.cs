using System.Collections.Generic;
using System.Threading.Tasks;
using Celo.Service.Models.ServiceModels;
using Celo.Service.Models.ServiceModels.Request;

namespace Celo.Service.RandomUser.Service
{
    public class UserService : IUserService
    {
        private readonly IUserDataProvider _dataservice;
        public UserService(IUserDataProvider dataservice) => _dataservice = dataservice;
        public Task<bool> DeleteUserAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<UserResponse>> GetUserAsync(UserRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateUserAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}