using Celo.Service.Models.ServiceModels.Request;
using Microsoft.AspNetCore.Mvc;

namespace Celo.Service.RandomUser.ResponseUtil
{
     public static class ResponseMapper
     {
        private const string NoContentFoundDescription = "No Content found";

        public static IActionResult MapResponse(this DataOperationStatus status, string action, object dataObject)
         {
             switch (status)
             {
                 case DataOperationStatus.DeleteFailedError: 
                 case DataOperationStatus.NoDeleteCarriedOut:
                 case DataOperationStatus.UpdateFailedError:
                 case DataOperationStatus.NoUpdateCarriedOut:
                    return new NoContentResult();
                 case DataOperationStatus.DeleteSuccess:
                 case DataOperationStatus.UpdateSuccess:
                      return new CreatedResult(action, dataObject);
                default:
                    return new StatusCodeResult(405);
             }
         }
     }
}