using Celo.Service.RandomUser.Controllers;
using Celo.Service.RandomUser.Service;
using Microsoft.Extensions.Logging;

namespace Celo.Service.RandomUser.UnitTests.Controllers
{
    public class ControllerTestInstance
    {
        public ILogger<UserController> LoggerInstance { get; set; }

        public IUserService UserService { get; set; }

        public ICreateUserService CreateUserService { get; set; }
    }
}