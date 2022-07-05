using System.Net;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Mc2.CrudTest.Application.Common.Models;

namespace Mc2.CrudTest.WebApi.Helpers
{
    public class ApiResultHelper
    {
        public static IActionResult GenerateOkResult(object actionResult)
        {
            if (actionResult is OkResult okResult)
            {
                var apiResult = new ApiResult<object>(HttpStatusCode.OK);

                return new JsonResult(apiResult) { StatusCode = (int)HttpStatusCode.OK };
            }

            else if (actionResult is OkObjectResult okObjectResult)
            {
                var apiResult = new ApiResult<object>(HttpStatusCode.OK, okObjectResult.Value);

                return new JsonResult(apiResult) { StatusCode = (int)HttpStatusCode.OK };
            }

            else if (actionResult is ContentResult contentResult)
            {
                var apiResult = new ApiResult<object>(HttpStatusCode.OK, (object)contentResult.Content);

                return new JsonResult(apiResult) { StatusCode = (int)HttpStatusCode.OK };
            }

            return null;
        }

        public static IActionResult GenerateBadRequestResult(object actionResult)
        {
            if (actionResult is BadRequestResult badRequestResult)
            {
                var apiResult = new ApiResult<object>(HttpStatusCode.BadRequest);

                return new JsonResult(apiResult) { StatusCode = (int)HttpStatusCode.BadRequest };
            }

            else if (actionResult is BadRequestObjectResult badRequestObjectResult)
            {
                IEnumerable<string> errors = GetErrors(badRequestObjectResult.Value);

                var apiResult = new ApiResult<object>(HttpStatusCode.BadRequest, errors);

                return new JsonResult(apiResult) { StatusCode = (int)HttpStatusCode.BadRequest };
            }

            return null;
        }

        public static IActionResult GenerateNotFoundResult(object actionResult)
        {
            if (actionResult is NotFoundResult notFoundResult)
            {
                var apiResult = new ApiResult<object>(HttpStatusCode.NotFound);

                return new JsonResult(apiResult) { StatusCode = (int)HttpStatusCode.NotFound };
            }

            else if (actionResult is NotFoundObjectResult notFoundObjectResult)
            {
                IEnumerable<string> errors = GetErrors(notFoundObjectResult.Value);

                var apiResult = new ApiResult<object>(HttpStatusCode.NotFound, errors);

                return new JsonResult(apiResult) { StatusCode = (int)HttpStatusCode.NotFound };
            }

            return null;
        }

        public static IActionResult GenerateForbiddenResult(object actionResult)
        {
            if (actionResult is ForbidResult forbiddenResult)
            {
                var apiResult = new ApiResult<object>(HttpStatusCode.Forbidden);

                return new JsonResult(apiResult) { StatusCode = (int)HttpStatusCode.Forbidden };
            }

            return null;
        }

        public static IActionResult GenerateUnauthorizedResult(object actionResult)
        {
            if (actionResult is UnauthorizedResult unAuthorizedResult)
            {
                var apiResult = new ApiResult<object>(HttpStatusCode.Unauthorized);

                return new JsonResult(apiResult) { StatusCode = (int)HttpStatusCode.Unauthorized };
            }

            else if (actionResult is UnauthorizedObjectResult unauthorizedObjectResult)
            {
                IEnumerable<string> errors = GetErrors(unauthorizedObjectResult.Value);

                var apiResult = new ApiResult<object>(HttpStatusCode.Unauthorized, errors);

                return new JsonResult(apiResult) { StatusCode = (int)HttpStatusCode.Unauthorized };
            }

            return null;
        }

        public static IActionResult GenerateOkResult()
        {
            var apiResult = new ApiResult<object>(HttpStatusCode.OK);

            return new JsonResult(apiResult) { StatusCode = (int)HttpStatusCode.OK };
        }

        public static IActionResult GenerateNotFoundResult()
        {
            var errorMessage = "The requested data or file is not found.";

            var apiResult = new ApiResult<object>(HttpStatusCode.NotFound, errorMessage);

            return new JsonResult(apiResult) { StatusCode = (int)HttpStatusCode.NotFound };
        }

        public static IActionResult GenerateBadRequestResult()
        {
            var errorMessage = "We can't process the request due to something that is perceived to be a client error. the error could be for malformed request syntax, invalid request message framing, deceptive request routing etc.";

            var apiResult = new ApiResult<object>(HttpStatusCode.BadRequest, errorMessage);

            return new JsonResult(apiResult) { StatusCode = (int)HttpStatusCode.BadRequest };
        }

        public static IActionResult GenerateServerErrorResult()
        {
            var errorMessage = "An error occurred in the server. Please try again later or contact to the service owner.";

            var apiResult = new ApiResult<object>(HttpStatusCode.InternalServerError, errorMessage);

            return new JsonResult(apiResult) { StatusCode = (int)HttpStatusCode.InternalServerError };
        }

        public static IActionResult GenerateUnsupportedMediaTypeResult()
        {
            var errorMessage = "The payload format is in an unsupported format.";

            var apiResult = new ApiResult<object>(HttpStatusCode.UnsupportedMediaType, errorMessage);

            return new JsonResult(apiResult) { StatusCode = (int)HttpStatusCode.UnsupportedMediaType };
        }

        public static IEnumerable<string> GetErrors(object actionResult)
        {
            IEnumerable<string> errors = new List<string>();

            if (actionResult is SerializableError serializableErrors)
                errors = serializableErrors.SelectMany(e => (IEnumerable<string>)e.Value).Distinct();

            else if (actionResult is ValidationProblemDetails validationErrors)
                errors = validationErrors.Errors.SelectMany(e => e.Value).Distinct();

            else if (actionResult is string customError)
            {
                var customErrors = new List<string>();
                customErrors.Add(customError);
                errors = customErrors;
            }

            else
                errors = (IEnumerable<string>)actionResult;

            return errors;
        }
    }
}
