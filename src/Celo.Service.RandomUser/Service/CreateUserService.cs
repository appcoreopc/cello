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
        private const int MaxRecordToCreate = 30;
        private const string LocalUserTitle = "Demo Random User";
        private readonly IUserService _dataProvider;

        public CreateUserService(IUserService dataProvider) => _dataProvider = dataProvider;

        public async Task CreateUserAsync()
        {
            var randomizer = new System.Random();

            for (int i = 0; i < MaxRecordToCreate; i++)
            {
                await _dataProvider.CreateUserAsync(new User
                {
                    Id = i + randomizer.Next(MinValue, MaxValue),
                    FirstName = LocalUserName + i,
                    LastName = LocalUserLastName,
                    Title = LocalUserTitle,
                    Dob = System.DateTime.Now,
                    Email = LocalFakeEmail,
                    LargePictureUrl = "https://randomuser.me/api/portraits/men/75.jpg",
                    MediumPictureUrl = "https://randomuser.meapi/portraits/men/75.jpg",
                    ThumbNail = "https://randomuser.me/api/portraits/men/75.jpg",
                    Phone = $"0800-999-{i}"
                });
            }
        }
    }
}