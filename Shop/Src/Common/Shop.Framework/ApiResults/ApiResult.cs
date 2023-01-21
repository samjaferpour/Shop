using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Framework.ApiResults
{
    public class ApiResult
    {
        public bool IsSuccess { get; set; }
        public ApiResultStatusCode StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;

        public ApiResult(bool isSuccess, ApiResultStatusCode statusCode, string message = null!, object data = null!)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message;
        }
        #region Implicit Operators
        public static implicit operator ApiResult(OkResult result)
        {
            return new ApiResult(true, ApiResultStatusCode.Success);
        }
        public static implicit operator ApiResult(ContentResult result)
        {
            return new ApiResult(true, ApiResultStatusCode.Success, result.Content);
        }
        public static implicit operator ApiResult(NotFoundResult result)
        {
            return new ApiResult(false, ApiResultStatusCode.NotFound);
        }
        public static implicit operator ApiResult(BadRequestResult result)
        {
            return new ApiResult(false, ApiResultStatusCode.BadRequest);
        }
        #endregion
    }
    public class ApiResult<TData> : ApiResult
         where TData : class
    {
        public TData Data { get; set; }
        public ApiResult(bool isSuccess, ApiResultStatusCode statusCode, string message, TData data) 
            : base(isSuccess, statusCode, message)
        {
            Data = data;
        }
        #region implicit operators
        public static implicit operator ApiResult<TData>(OkResult result)
        {
            return new ApiResult<TData>(true, ApiResultStatusCode.Success, "عملیات با موفقیت انجام پذیرفت",null!);
        }
        public static implicit operator ApiResult<TData>(OkObjectResult result)
        {
            return new ApiResult<TData>(true, ApiResultStatusCode.Success, "عملیات با موفقیت انجام پذیرفت", (TData)result.Value);
        }
        public static implicit operator ApiResult<TData>(NotFoundResult result)
        {
            return new ApiResult<TData>(false, ApiResultStatusCode.NotFound, "یافت نشد", null!);
        }
        public static implicit operator ApiResult<TData>(NotFoundObjectResult result)
        {
            return new ApiResult<TData>(false, ApiResultStatusCode.NotFound, "یافت نشد", (TData)result.Value);
        }
        public static implicit operator ApiResult<TData>(BadRequestResult result)
        {
            return new ApiResult<TData>(false, ApiResultStatusCode.BadRequest, "پارامترهای ورودی اشتباه است", null!);
        }
        public static implicit operator ApiResult<TData>(BadRequestObjectResult result)
        {
            return new ApiResult<TData>(false, ApiResultStatusCode.BadRequest, "پارامترهای ورودی اشتباه است", (TData)result.Value);
        }
        #endregion
    }
}
