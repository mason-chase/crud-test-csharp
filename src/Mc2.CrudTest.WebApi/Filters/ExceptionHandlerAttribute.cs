using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Filters;
using Mc2.CrudTest.Application.Common.Exceptions;

namespace Mc2.CrudTest.WebApi.Filters
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ExceptionHandlerAttribute()
        {
            // Register known exception types and handlers.
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(NotFoundException), HandleNotFoundException },
            };
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        #region handlers

        private void HandleException(ExceptionContext context)
        {
            var type = context.Exception.GetType();

            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);

                return;
            }

            HandleUnknownException(context);
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status404NotFound);

            context.ExceptionHandled = true;
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);

            context.ExceptionHandled = true;
        }

        #endregion;
    }
}
