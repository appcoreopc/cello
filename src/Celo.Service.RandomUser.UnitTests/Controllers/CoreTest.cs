using Celo.Service.RandomUser.Controllers;
using Celo.Service.RandomUser.Service;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Celo.Service.RandomUser.UnitTests.Controllers
{
    public class CoreTest
    {
        protected ControllerTestInstance CreateInstance()
        {

            return new ControllerTestInstance
            {
                LoggerInstance = Substitute.For<ILogger<UserController>>(),
                UserService = Substitute.For<IUserService>()
            };
        }
    }
}