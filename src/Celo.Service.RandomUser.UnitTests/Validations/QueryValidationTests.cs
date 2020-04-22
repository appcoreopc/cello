using Xunit;
using Celo.Service.RandomUser.Validations;
using Celo.Service.RandomUser.Constants;
using Celo.Service.Models.ServiceModels.Request;

namespace Celo.Service.RandomUser.UnitTests.Validations
{
    public class QueryValidationTests : CoreTest
    {

        [Fact]
        public void WhenPageNumberIsBelowZeroThenSendToDefaultOne()
        {
            var target = new QueryValidator();
            var page = target.ValidateUserQueryRequest(FakeMinusZeroTotalPageUserGetRequest());
            Assert.True(page.TotalRecordRequested == AppConstant.DefaultPageSie);
        }

        [Fact]
        public void WhenPageNumberIsGivenThenUseThePageValue()
        {
            var fakeValidTotalPageUserRequset = new UserGetRequest
            {
                FirstName = fakeFirstName,
                LastName = fakeLastName,
                TotalRecordRequested = 100
            };

            var target = new QueryValidator();
            var page = target.ValidateUserQueryRequest(fakeValidTotalPageUserRequset);
            Assert.True(page.TotalRecordRequested == fakeValidTotalPageUserRequset.TotalRecordRequested);
        }


        [Fact]
        public void WhenNameQueryIsGivenThenQueryTypeIsName()
        {
            var fakeValidTotalPageUserRequset = new UserGetRequest
            {
                FirstName = fakeFirstName,
                LastName = fakeLastName,
                TotalRecordRequested = 20
            };

            var target = new QueryValidator();
            var page = target.ValidateUserQueryRequest(fakeValidTotalPageUserRequset);

            Assert.Equal(QueryRequestType.NameQuery, page.QueryRequestType);
            Assert.True(page.TotalRecordRequested == fakeValidTotalPageUserRequset.TotalRecordRequested);
        }


         [Fact]
        public void WhenEmptyFirstNameLastNameIsGivenThenQueryTypeIsName()
        {
            var fakeValidTotalPageUserRequset = new UserGetRequest
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                TotalRecordRequested = 20
            };
            
            var target = new QueryValidator();
            var page = target.ValidateUserQueryRequest(fakeValidTotalPageUserRequset);

            Assert.Equal(QueryRequestType.RandomQuery, page.QueryRequestType);
            Assert.True(page.TotalRecordRequested == fakeValidTotalPageUserRequset.TotalRecordRequested);
        }
    }
}