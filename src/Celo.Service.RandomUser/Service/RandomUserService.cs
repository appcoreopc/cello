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

        public async Task<IEnumerable<UsersDetails>> GetUserAsync(UserGetRequest request)
        {

            await _dataservice.GetUserAsync();


            return await Task.FromResult(new List<UsersDetails>() {
                new UsersDetails()
            });
        }

        public Task<bool> UpdateUserAsync(UserUpdateRequest request)
        {
            return Task.FromResult(true);
        }

        public Task<bool> DeleteUserAsync(int request)
        {
            return Task.FromResult(true);
        }
    }
}