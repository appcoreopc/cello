using Celo.Data.InMemory;
using Celo.Service.Models.ServiceModels.Request;
using Celo.Service.RandomUser.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Celo.Service.RandomUser.UnitTests.Service
{
    public class UserDataProviderTests : CoreTest
    {

        [Fact]
        public void WhenDeleteAsyncExecuteSuccessThenDeleteSuccessDataOperationReturned()
        {

            // var data = new List<User>
            // {
            //     new User { FirstName = "BBB" },
            //     new User { FirstName = "ZZZ" },
            //     new User { FirstName = "AAA" },
            // }.AsQueryable();

            // var mockSet = Substitute.For<IDbSet<User>>();
            // mockSet.Provider.Returns(data.Provider);
            // mockSet.Expression.Returns(data.Expression);
            // mockSet.ElementType.Returns(data.ElementType);
            // mockSet.GetEnumerator().Returns(data.GetEnumerator());

            // var mockContext = Substitute.For<UserDataContext>();
            // mockContext.User.Returns(mockSet);

            var logger = Substitute.For<ILogger<UserDataProvider>>();




            // var target = new UserDataProvider(mockService.DataContext, mockService.Logger);

            // var result = target.DeleteUserAsync(fakeUserId).Result;

            // Assert.True(result == DataOperationStatus.DeleteSuccess);

        }

        private MockDataProviderObject CreateMockService() => new MockDataProviderObject
        {
            DataContext = Substitute.For<UserDataContext>(),
            Logger = Substitute.For<Logger<UserDataProvider>>()
        };

    }

    class MockDataProviderObject
    {

        public UserDataContext DataContext { get; set; }

        public ILogger<UserDataProvider> Logger { get; set; }
    }
}