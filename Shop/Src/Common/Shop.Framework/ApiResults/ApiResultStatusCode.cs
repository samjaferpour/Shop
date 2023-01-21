using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Framework.ApiResults
{
    public enum ApiResultStatusCode
    {
        [Display(Name = "عملیات با موفقیت انجام پذیرفت")]
        Success = 0,
        [Display(Name = "خطای سمت سرور")]
        ServerError = 1,
        [Display(Name = "مقادیر ورودی اشتباه است")]
        BadRequest = 2,
        [Display(Name = "یافت نشد")]
        NotFound = 3,
        [Display(Name = "دسترسی کاربر به این قسمت مجاز نمی باشد")]
        UnAuthorized = 4,
        [Display(Name = "لیست خالی است")]
        EmptyList = 5,
        [Display(Name = "خطا در منطق برنامه")]
        LogicError = 6,
    }
}
