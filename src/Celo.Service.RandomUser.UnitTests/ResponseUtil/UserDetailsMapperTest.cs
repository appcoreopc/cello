using Xunit;
using System.Linq;
using Celo.Service.RandomUser.ResponseUtil;
using Celo.Service.Models.ServiceModels;

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
    }
}