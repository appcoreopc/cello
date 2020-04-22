using Xunit;
using Celo.Service.Models.ServiceModels.Request;

using Celo.Service.RandomUser.ResponseUtil;
using Microsoft.AspNetCore.Mvc;

namespace Celo.Service.RandomUser.UnitTests.ResponseUtil
{
    public class ResponseUtilTest 
    {
        private const string Action = "FakeUrlAction";

        [Fact]
        public void WhenUpdateSuccessfulThen201Returned()
        {
            object dataObject = new object();
            var result = ResponseMapper.MapResponse(DataOperationStatus.UpdateSuccess, Action, dataObject);
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public void WhenDeleteSuccessfulThen201Returned()
        {
            object dataObject = new object();
            var result = ResponseMapper.MapResponse(DataOperationStatus.DeleteSuccess, Action, dataObject);
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public void WhenUpdateFailThenNoContentReturned()
        {
            object dataObject = new object();
            var result = ResponseMapper.MapResponse(DataOperationStatus.NoUpdateCarriedOut, Action, dataObject);
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}