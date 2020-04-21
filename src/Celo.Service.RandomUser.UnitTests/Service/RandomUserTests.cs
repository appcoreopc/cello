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
            var dataProviderService = this.CreateMock();
            
            dataProviderService.GetUserAsync(Arg.Any<UserGetRequest>()).Returns(Task.FromResult(GetFakeDatabaseUserData()));
            
            var target = new RandomUserService(dataProviderService);
            var result = target.GetUserAsync(new UserGetRequest()).Result;
           
            dataProviderService.Received().GetUserAsync(Arg.Any<UserGetRequest>());
            Assert.True(result.Count() == 2);
        }

        [Fact]
        public void WhenGetUserExecutesReturnSingleResultThenResultIsOne()
        {
            var dataProviderService = this.CreateMock();
            
            dataProviderService.GetUserAsync(Arg.Any<UserGetRequest>()).Returns(Task.FromResult(GetFakeSingleDatabaseUserData()));
            
            var target = new RandomUserService(dataProviderService);
            var result = target.GetUserAsync(new UserGetRequest()).Result;
           
            dataProviderService.Received().GetUserAsync(Arg.Any<UserGetRequest>());
            Assert.True(result.Count() == 1);
        }

        [Fact]
        public void WhenUpdateUserExecutesThenReturnStatusOk()
        {
            var dataProviderService = this.CreateMock();
            var target = new RandomUserService(dataProviderService);

            dataProviderService.UpdateUserAsync(Arg.Any<UserUpdateRequest>()).Returns(Task.FromResult(DataOperationStatus.UpdateSuccess));

            var result = target.UpdateUserAsync(this.FakeUserUpdateRequest()).Result;
           
            Assert.True(result == DataOperationStatus.UpdateSuccess);
            dataProviderService.Received().UpdateUserAsync(Arg.Any<UserUpdateRequest>());
        }


        [Fact]
        public void WhenDeleteUserExecutesThenReturnStatusOk()
        {
            var dataProviderService = this.CreateMock();
            var target = new RandomUserService(dataProviderService);

            int fakeUserId = 1;

            dataProviderService.DeleteUserAsync(Arg.Any<int>()).Returns(Task.FromResult(DataOperationStatus.DeleteSuccess));

            var result = target.DeleteUserAsync(fakeUserId).Result;
           
            Assert.True(result == DataOperationStatus.DeleteSuccess);
            dataProviderService.Received().DeleteUserAsync(fakeUserId);
        }

        private IUserDataProvider CreateMock()
        {
            return Substitute.For<IUserDataProvider>();
        }
    }
}