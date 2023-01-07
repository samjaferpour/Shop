using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Framework.ApiResults
{
    public enum ApiResultStatusCode
    {
        Success = 0,
        ServerError = 1,
        BadRequest = 2,
        NotFound = 3,
        UnAuthorized = 4,
        EmptyList = 5,
        LogicError = 6,
    }
}
