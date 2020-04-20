using System.Collections.Generic;
using System.Threading.Tasks;
using Celo.Service.Models.ServiceModels;
using Celo.Service.Models.ServiceModels.Request;

namespace Celo.Service.RandomUser.Service
{
    public class RandomUserService : IUserService
    {
        private readonly IUserDataProvider _dataservice;
        public RandomUserService(IUserDataProvider dataservice) => _dataservice = dataservice;

        public Task<bool> DeleteUserAsync()
        {
            return Task.FromResult(true);
        }

        public async Task<IEnumerable<UserResponse>> GetUserAsync(UserGetRequest request)
        {
            return await Task.FromResult(new List<UserResponse>() {
                new UserResponse()
            });
        }

        public Task<bool> UpdateUserAsync()
        {
            return Task.FromResult(true);
        }
    }
}