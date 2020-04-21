using Celo.Service.Models.ServiceModels.Request;
using Microsoft.AspNetCore.Mvc;

namespace Celo.Service.RandomUser.ResponseUtil
{
     public static class ResponseMapper
     {
         public static IActionResult MapResponse(this DataOperationStatus status, ControllerBase controller, string action, object dataObject)
         
         {
             switch (status)
             {
                 case DataOperationStatus.DeleteFailedError: 
                 case DataOperationStatus.NoDeleteCarriedOut:
                 case DataOperationStatus.UpdateFailedError:
                 case DataOperationStatus.NoUpdateCarriedOut:
                    return controller.NoContent();
                 case DataOperationStatus.DeleteSuccess:
                 case DataOperationStatus.UpdateSuccess:
                       return  controller.CreatedAtAction(action, dataObject);
                default:
                    return new OkResult();
             }
         }
     }
}