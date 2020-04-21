using Celo.Service.Models.ServiceModels.Request;

namespace Celo.Service.RandomUser.Validations
{
    internal interface IQueryValidator
    {
         UserGetRequest ValidateUserQueryRequest(UserGetRequest request);
    }
}