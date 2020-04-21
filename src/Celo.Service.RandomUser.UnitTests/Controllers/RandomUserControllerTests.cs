using Celo.Service.Models.ServiceModels.Request;
using Celo.Service.RandomUser.Controllers;
using NSubstitute;
using Xunit;

namespace Celo.Service.RandomUser.UnitTests.Controllers
{
    public class ControllerTests : CoreTest
    {
         private ControllerTestInstance _mockService; 

        [Fact]
        public void WhenUserControllerGetUsersExecuteThenExpectListOfUsers()
        {
           _mockService = this.CreateInstance();

           var controller = new UserController(_mockService.UserService, _mockService.LoggerInstance);

          var result = controller.GetUsers(this.FakeUserGetRequest());

          _mockService.UserService.Received().GetUserAsync(Arg.Any<UserGetRequest>());

        }

        [Fact]
        public void WhenUserControllerSingleRequestThenExpectOneUser()
        {
           _mockService = this.CreateInstance();

           var controller = new UserController(_mockService.UserService, _mockService.LoggerInstance);
           var result = controller.GetUsers(this.FakeUserGetRequest());
           _mockService.UserService.Received().GetUserAsync(Arg.Any<UserGetRequest>());
        }

         [Fact]
        public void WhenUserControllerUpdateThenUserUpdateServiceCalleds()
        {
           _mockService = this.CreateInstance();

           var controller = new UserController(_mockService.UserService, _mockService.LoggerInstance);
           var result = controller.UpdateUserAsync(this.FakeUserUpdateRequest());

            _mockService.UserService.Received().UpdateUserAsync(Arg.Any<UserUpdateRequest>());
        }

         [Fact]
        public void WhenUserControllerDeleteThenUserDeleteServiceCalled()
        {
           _mockService = this.CreateInstance();

           var controller = new UserController(_mockService.UserService, _mockService.LoggerInstance);
           var result = controller.DeleteAsync(1);

           _mockService.UserService.Received().DeleteUserAsync(Arg.Any<int>());
          
        }
    }
}