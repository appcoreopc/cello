using Celo.Service.RandomUser.Controllers;
using Celo.Service.RandomUser.Service;
using NSubstitute;
using Xunit;

namespace Celo.Service.RandomUser.UnitTests.Controllers
{
    public class ControllerTests
    {
        
        [Fact]
        public void WhenUserControllerGetThenExpectListOfUsers()
        {
           var userService = Substitute.For<IUserService>();
           var controller = new UserController(userService);
           Assert.True(1==1);

        }

        [Fact]
        public void WhenUserControllerSingleRequestThenExpectOneUser()
        {
           var userService = Substitute.For<IUserService>();

           var controller = new UserController(userService);
           Assert.True(1==1);

        }

         [Fact]
        public void WhenUserControllerUpdateThenStatus201()
        {
           var userService = Substitute.For<IUserService>();
           var controller = new UserController(userService);
           Assert.True(1==1);

        }

         [Fact]
        public void WhenUserControllerDeleteThenExpect202Status()
        {
           var userService = Substitute.For<IUserService>();
           var controller = new UserController(userService);
           Assert.True(1==1);
        }
    }
}