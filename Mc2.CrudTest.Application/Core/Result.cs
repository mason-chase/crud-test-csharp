using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }

        public T Value { get; set; }

        public string Error { get; set; }

        public static Result<T> Success(T value) => new Result<T> { IsSuccess = true, Value = value };

        public static Result<T> Failure(string error) => new Result<T> { IsSuccess = false, Error = error };

        public static Result<T> CreateResult(
            bool result,
            T value,
            string error)
        {
            return result ?
                Success(value) :
                Failure(error);
        }
    }
}
