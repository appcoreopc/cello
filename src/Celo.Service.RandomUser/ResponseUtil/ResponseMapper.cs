using System;
using Celo.Service.Models.ServiceModels.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

using Microsoft.Extensions.Logging;
namespace Celo.Service.RandomUser.ResponseUtil
{
     public static class ResponseMapper
     {
         // can't use new switch 
         public static IActionResult MapResponse(this DataOperationStatus status, ControllerBase controllerbase)
         
         {
             switch (status)
             {
                 case DataOperationStatus.DeleteFailedError: 
                 case DataOperationStatus.NoDeleteCarriedOut:
                 case DataOperationStatus.UpdateFailedError:
                 case DataOperationStatus.NoUpdateCarriedOut:
                    return new NotFoundObjectResult("No resource found");
                //  case DataOperationStatus.DeleteSuccess:
                //     return  controllerbase.CreatedAtAction("userdeleted","");
                //  case DataOperationStatus.UpdateSuccess:
                //     return new CreatedAtActionResult("/user", "");
                default:
                    return new OkResult();
             }
         }
     }
}