using Xunit;
using NSubstitute;
using Celo.Service.RandomUser.Service;
using Celo.Service.RandomUser.UnitTests.Controllers;
using Celo.Service.Models.ServiceModels.Request;
using System.Threading.Tasks;
using System.Linq;

namespace Celo.Service.RandomUser.UnitTests.Service
{
    public class RandomUserTests : CoreTest
    {
        [Fact]
        public void WhenGetUserExecutesReturnSingleResultThenResultUserResponse()
        {
            var serviceMock = this.CreateMock();
            var target = new RandomUserService(serviceMock);

            target.GetUserAsync(Arg.Any<UserGetRequest>()).Returns(Task.FromResult(GetSingleUserResponse().Users));
            var result = target.GetUserAsync(this.FakeUserGetRequest()).Result;

            Assert.True(result.Count() == 1);
            serviceMock.Received().GetUserAsync(Arg.Any<UserGetRequest>());
        }

        [Fact]
        public void WhenGetUserExecutesReturnSingleResultThenResultIsOne()
        {
            var serviceMock = this.CreateMock();
            var target = new RandomUserService(serviceMock);

            target.GetUserAsync(Arg.Any<UserGetRequest>()).Returns(Task.FromResult(GetArrayUserResponse().Users));
            var result = target.GetUserAsync(this.FakeUserGetRequest()).Result;

            Assert.True(result.Count() == GetArrayUserResponse().Users.Count());
            serviceMock.Received().GetUserAsync(Arg.Any<UserGetRequest>());
        }


        [Fact]
        public void WhenUpdateUserExecutesThenReturnStatusOk()
        {
            var serviceMock = this.CreateMock();
            var target = new RandomUserService(serviceMock);

            var result = target.UpdateUserAsync(this.FakeUserUpdateRequest());

            Assert.IsType<DataOperationStatus>(result);
            serviceMock.Received().UpdateUserAsync(Arg.Any<UserUpdateRequest>());
        }


        [Fact]
        public void WhenDeleteUserExecutesThenReturnStatusOk()
        {
            var serviceMock = this.CreateMock();
            var target = new RandomUserService(serviceMock);

            var result = target.DeleteUserAsync(this.fakeUserId);

            Assert.IsType<DataOperationStatus>(result);
            serviceMock.Received().DeleteUserAsync(Arg.Any<int>());
        }

        private IUserDataProvider CreateMock()
        {
            return Substitute.For<IUserDataProvider>();
        }
    }
}