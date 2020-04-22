using Celo.Service.Models.ServiceModels.Request;
using Celo.Service.RandomUser.Constants;

namespace Celo.Service.RandomUser.Validations
{
    class QueryValidator : IQueryValidator {

        public UserGetRequest ValidateUserQueryRequest(UserGetRequest request)
        {   
            request.TotalRecordRequested = request.TotalRecordRequested <= 0 ? AppConstant.DefaultPageSie : request.TotalRecordRequested;
            
            if (!string.IsNullOrWhiteSpace(request.FirstName) || !string.IsNullOrWhiteSpace(request.LastName))
            {
                request.QueryRequestType = QueryRequestType.NameQuery;
            }
            else 
            {
                 request.QueryRequestType = QueryRequestType.RandomQuery;
            }

            return request;
        }
    }
}
