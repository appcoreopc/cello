using Xunit;
using System.Linq;
using Celo.Service.RandomUser.ResponseUtil;
using Celo.Service.Models.ServiceModels;
using Celo.Data.InMemory;

namespace Celo.Service.RandomUser.UnitTests.ResponseUtil
{
    public class UserDetailsMapperTest : CoreTest
    {
        [Fact]
        public void WhenConvertSucessfulThenUserDetailsTypeReturned()
        {
           var target = GetFakeSingleDatabaseUserData().MapToUserDetails();
           
           var targetObject = target.FirstOrDefault();
           Assert.NotNull(target);
           Assert.True(target.Count() == 1);
           Assert.IsType<UsersDetails>(targetObject);

           Assert.Equal(fakeFirstName, targetObject.Name.First);
           Assert.Equal(fakeUserEmail, targetObject.Email);
        }

        [Fact]
        public void WhenMappingCompleteThenUpdateUserRequestTransferedToUserObject()
        {
            var userRequest = FakeUserUpdateRequest();
            var user = new User();

            var target = userRequest.MapElementToUserDataObject(user);
            Assert.Equal(fakeFirstName, target.FirstName);
            Assert.Equal(fakeLastName, target.LastName);
            Assert.Equal(fakeUserEmail, target.Email);
        }
    }
}