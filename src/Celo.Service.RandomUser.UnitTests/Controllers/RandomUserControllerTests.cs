using System.Collections.Generic;
using System.Threading.Tasks;
using Celo.Service.Models.ServiceModels.Request;
using Celo.Service.RandomUser.Controllers;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Celo.Service.Models.ServiceModels;
using Xunit;
using System.Linq;

namespace Celo.Service.RandomUser.UnitTests.Controllers
{
    public class ControllerTests : CoreTest
    {
        private const int UserId = 1;
        private ControllerTestInstance _mockService;

        [Fact]
        public void WhenUserControllerGetUsersExecuteThenExpectListOfUsers()
        {
            _mockService = this.CreateInstance();
            _mockService.UserService.GetUserAsync(Arg.Any<UserGetRequest>()).Returns(Task.FromResult(GetUserDetailsList()));

            var controller = CreateTarget();
            var serviceResponse = controller.GetUsersAsync(this.FakeUserGetRequest()).Result;
            var okResult = serviceResponse.Result as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            var resultValue = okResult.Value as IEnumerable<UsersDetails>;
            Assert.True(resultValue.Count() == 2);
            _mockService.UserService.Received().GetUserAsync(Arg.Any<UserGetRequest>());
        }

        [Fact]
        public void WhenNoMatchingRequestFoundThenExpectEmptyListUserDetail()
        {
            _mockService = this.CreateInstance();
            _mockService.UserService.GetUserAsync(Arg.Any<UserGetRequest>()).Returns(Task.FromResult(GetEmptyUserDetailsList()));

            var controller = CreateTarget();

            var serverResponse = controller.GetUsersAsync(this.FakeUserGetRequest()).Result;
            var servicResponseResult = serverResponse.Result as OkObjectResult;

            Assert.NotNull(servicResponseResult);
            Assert.Equal(200, servicResponseResult.StatusCode);
            var resultValue = servicResponseResult.Value as IEnumerable<UsersDetails>;
            Assert.True(resultValue.Count() == 0);
            _mockService.UserService.Received().GetUserAsync(Arg.Any<UserGetRequest>());

        }

        [Fact]
        public void WhenUserControllerUpdateSuccessThenReturnsCreatedAtResults()
        {
            _mockService = this.CreateInstance();

            _mockService.UserService.UpdateUserAsync(Arg.Any<UserUpdateRequest>()).Returns(Task.FromResult(DataOperationStatus.UpdateSuccess));

            var controller = CreateTarget();
            var serverResponse = controller.UpdateUserAsync(this.FakeUserUpdateRequest()).Result;

            var servicResponseResult = serverResponse as CreatedResult;
            Assert.True(servicResponseResult.StatusCode == 201);

            _mockService.UserService.Received().UpdateUserAsync(Arg.Any<UserUpdateRequest>());
        }

        [Fact]
        public void WhenUserControllerUpdateErrorThenReturnsNoContentFoundStatus()
        {
            _mockService = this.CreateInstance();

            _mockService.UserService.UpdateUserAsync(Arg.Any<UserUpdateRequest>()).Returns(Task.FromResult(DataOperationStatus.UpdateFailedError));

            var controller = CreateTarget();
            var serverResponse = controller.UpdateUserAsync(this.FakeUserUpdateRequest()).Result;

            var servicResponseResult = serverResponse as NoContentResult;
            Assert.True(servicResponseResult.StatusCode == 204  );

            _mockService.UserService.Received().UpdateUserAsync(Arg.Any<UserUpdateRequest>());
        }

        [Fact]
        public void WhenUserControllerDeleteSuccessThenReturnCreatedAtResults()
        {
            _mockService = this.CreateInstance();

            _mockService.UserService.DeleteUserAsync(Arg.Any<int>()).Returns(Task.FromResult(DataOperationStatus.DeleteSuccess));

            var controller = CreateTarget();
            var serverResponse = controller.DeleteAsync(UserId).Result;

            var servicResponseResult = serverResponse as CreatedResult;
            Assert.True(servicResponseResult.StatusCode == 201);

            _mockService.UserService.Received().DeleteUserAsync(Arg.Any<int>());
        }

        [Fact]
        public void WhenUserControllerDeleteFailThenReturnNoContent()
        {
            _mockService = this.CreateInstance();

            _mockService.UserService.DeleteUserAsync(Arg.Any<int>()).Returns(Task.FromResult(DataOperationStatus.DeleteFailedError));

            var controller = CreateTarget();
            var serverResponse = controller.DeleteAsync(UserId).Result;

            var servicResponseResult = serverResponse as NoContentResult;
            Assert.True(servicResponseResult.StatusCode == 204);

            _mockService.UserService.Received().DeleteUserAsync(Arg.Any<int>());
        }

        private UserController CreateTarget()
        {
            return new UserController(_mockService.UserService, _mockService.LoggerInstance,
            _mockService.CreateUserService);
        }
    }
}