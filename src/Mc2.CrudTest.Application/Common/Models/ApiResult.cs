using System;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Mc2.CrudTest.Application.Common.Models
{
    #region Base

    public class ApiResult
    {
        #region Members

        public HttpStatusCode ApiStatus { get; set; }
        public IEnumerable<string> ApiErrors { get; set; } = new List<string>();

        #endregion;

        #region Constructors

        public ApiResult(HttpStatusCode statusCode)
        {
            ApiStatus = statusCode;
        }

        public ApiResult(HttpStatusCode statusCode, string error) : this(statusCode)
        {
            var errors = new List<string> { error };

            ApiErrors = errors;
        }

        public ApiResult(HttpStatusCode statusCode, params string[] errors) : this(statusCode)
        {
            ApiErrors = errors;
        }

        public ApiResult(HttpStatusCode statusCode, IEnumerable<string> errors = null) : this(statusCode)
        {
            if(errors != null)
            {
                ApiErrors = errors;
            }
        }

        #endregion;
    }

    #endregion;

    #region Generic

    public class ApiResult<TData> : ApiResult where TData : class
    {
        #region Members

        public TData ApiData { get; set; }

        #endregion;

        #region Constructors

        public ApiResult(HttpStatusCode statusCode) : base(statusCode)
        {
        }

        public ApiResult(HttpStatusCode statusCode, TData data) : base(statusCode)
        {
            ApiData = data;
        }

        public ApiResult(HttpStatusCode statusCode, string error) : base(statusCode, error)
        {
        }

        public ApiResult(HttpStatusCode statusCode, params string[] errors) : base(statusCode, errors)
        {
        }

        public ApiResult(HttpStatusCode statusCode, IEnumerable<string> errors = null) : base(statusCode, errors)
        {
        }

        #endregion;
    }

    #endregion;
}
