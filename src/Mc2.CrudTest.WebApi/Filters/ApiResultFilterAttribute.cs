using System;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Mc2.CrudTest.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Mc2.CrudTest.WebApi.Filters
{
    public class ApiResultFilterAttribute : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            var actionResult = context.Result;

            if (actionResult is OkResult || actionResult is OkObjectResult || actionResult is ContentResult)
            {
                context.Result = ApiResultHelper.GenerateOkResult(actionResult);
            }

            else if (actionResult is BadRequestResult || actionResult is BadRequestObjectResult)
            {
                context.Result = ApiResultHelper.GenerateBadRequestResult(actionResult);
            }

            else if (actionResult is NotFoundResult || actionResult is NotFoundObjectResult)
            {
                context.Result = ApiResultHelper.GenerateNotFoundResult(actionResult);
            }

            else if (actionResult is UnauthorizedResult || actionResult is UnauthorizedObjectResult)
            {
                context.Result = ApiResultHelper.GenerateUnauthorizedResult(actionResult);
            }

            else if (actionResult is UnsupportedMediaTypeResult)
            {
                context.Result = ApiResultHelper.GenerateUnsupportedMediaTypeResult();
            }

            else if (actionResult is ForbidResult)
            {
                context.Result = ApiResultHelper.GenerateForbiddenResult(actionResult);
            }

            else if(actionResult is StatusCodeResult statusCodeResult)
            {
                var statusCode = statusCodeResult.StatusCode;

                if (statusCode >= 200 && statusCode < 300)
                {
                    context.Result = ApiResultHelper.GenerateOkResult(actionResult);
                }

                else if (statusCode >= 300 && statusCode < 400)
                {

                }

                else if (statusCode >= 400 && statusCode < 500)
                {
                    context.Result = ApiResultHelper.GenerateNotFoundResult(actionResult);
                }

                else if (statusCode >= 500 && statusCode < 600)
                {
                    context.Result = ApiResultHelper.GenerateServerErrorResult();
                }
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }
    }
}
