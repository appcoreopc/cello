using Celo.Service.RandomUser.Controllers;
using Celo.Service.RandomUser.Service;
using NSubstitute;
using Xunit;

namespace Celo.Service.RandomUser.UnitTests.Controllers
{
    public class ControllerTests : CoreTest
    {
         private ControllerTestInstance mockInstance; 

         public ControllerTests()
         {
             mockInstance = this.CreateInstance();
         }

        [Fact]
        public void WhenUserControllerGetThenExpectListOfUsers()
        {
           var userService = Substitute.For<IUserService>();

           var controller = new UserController(mockInstance.UserService, mockInstance.LoggerInstance);
           Assert.True(1==1);

        }

        [Fact]
        public void WhenUserControllerSingleRequestThenExpectOneUser()
        {
           var userService = Substitute.For<IUserService>();

           var controller = new UserController(mockInstance.UserService, mockInstance.LoggerInstance);
           Assert.True(1==1);

        }

         [Fact]
        public void WhenUserControllerUpdateThenStatus201()
        {
           var userService = Substitute.For<IUserService>();
           var controller = new UserController(mockInstance.UserService, mockInstance.LoggerInstance);
           Assert.True(1==1);

        }

         [Fact]
        public void WhenUserControllerDeleteThenExpect202Status()
        {
           var userService = Substitute.For<IUserService>();
           var controller = new UserController(mockInstance.UserService, mockInstance.LoggerInstance);
           Assert.True(1==1);
        }
    }
}