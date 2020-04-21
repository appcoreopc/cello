using System.Threading.Tasks;
using Celo.Data.InMemory;

namespace Celo.Service.RandomUser.Service
{
    public class CreateUserService
    {
        private const string LocalUserLastName = "LocalUserLastName";
        private const string LocalUserName = "LocalUser";
        private const string LocalFakeEmail = "fakeEmail@gmail.com";
        private const int MinValue = 200;
        private const int MaxValue = 30000;
        private readonly IUserService _dataProvider;

        public CreateUserService(IUserService dataProvider) => _dataProvider = dataProvider;

        public async Task CreateUserAsync()
        {
            var randomizer = new System.Random();

            for (int i = 0; i < 10; i++)
            {
                await _dataProvider.CreateUserAsync(new User
                {
                    Id = i + randomizer.Next(MinValue, MaxValue),
                    FirstName = LocalUserName + i,
                    LastName = LocalUserLastName,
                    Dob = System.DateTime.Now,
                    Email = LocalFakeEmail
                });
            }
        }
    }
}