// using System.Collections.Generic;
// using System.Linq;
// using Celo.Data.InMemory;
// using Celo.Service.Models.ServiceModels.Request;
// using Celo.Service.RandomUser.Service;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Logging;
// using NSubstitute;
// using Xunit;

// namespace Celo.Service.RandomUser.UnitTests.Service
// {
//     public class UserDataProviderTests : CoreTest
//     {

//         [Fact]
//         public void WhenDeleteAsyncExecuteSuccessThenDeleteSuccessDataOperationReturned()
//         {
//             var data = new List<User>
//             {
//                 new User { FirstName = "BBB" },
//                 new User { FirstName = "ZZZ" },
//                 new User { FirstName = "AAA" },

//             }.AsQueryable();

//             ///var mockSet = Substitute.For<DbSet<User>>();
//             var mockSet = Substitute.For<DbSet<User>, IQueryable<User>>();

//             ((IQueryable<User>) mockSet).Provider.Returns(data.Provider);
//             ((IQueryable<User>) mockSet).Expression.Returns(data.Expression);
//             ((IQueryable<User>) mockSet).ElementType.Returns(data.ElementType);
//             ((IQueryable<User>) mockSet).GetEnumerator().Returns(data.GetEnumerator());

//             var mockContext = Substitute.For<UserDataContext>();
//             mockContext.User.Returns(mockSet);

//             var logger = Substitute.For<ILogger<IUserDataProvider>>();

//             var target = new UserDataProvider(mockContext, logger);
//             var targetUser = new UserGetRequest {

//             };

//             var result = target.GetUserAsync(targetUser).Result;

//             Assert.True(1==1);


//             // var result = target.DeleteUserAsync(fakeUserId).Result;

//             // Assert.True(result == DataOperationStatus.DeleteSuccess);

//         }

//         private MockDataProviderObject CreateMockService() => new MockDataProviderObject
//         {
//             DataContext = Substitute.For<UserDataContext>(),
//             Logger = Substitute.For<Logger<UserDataProvider>>()
//         };

//     }

//     class MockDataProviderObject
//     {

//         public UserDataContext DataContext { get; set; }

//         public ILogger<UserDataProvider> Logger { get; set; }
//     }
// }