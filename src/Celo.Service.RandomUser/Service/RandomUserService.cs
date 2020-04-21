using System.Collections.Generic;
using System.Threading.Tasks;
using Celo.Data.InMemory;
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

            var result = await _dataservice.GetUserAsync(request);

            return await Task.FromResult(new List<UsersDetails>() {
                new UsersDetails()
            });
        }

        public Task<DataOperationStatus> UpdateUserAsync(UserUpdateRequest request)
        {
            return _dataservice.UpdateUserAsync(request);
        }

        public Task<DataOperationStatus> DeleteUserAsync(int request)
        {
            return _dataservice.DeleteUserAsync(request);
        }

        public async Task CreateUser(User user)
        {
             await _dataservice.CreateUserAsync(user);
        }
    }
}