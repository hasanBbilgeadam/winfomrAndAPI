using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication2.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            var value = context.HttpContext.Request.Path.ToString();
            context.Result = new JsonResult("bir hata meydana geldi daha sonra tekrar deneyiniz hatalı bir şekilde erişmeye çalıştığınız yer "+value);
        }
    }
}
