using WebApplication2.Context;

namespace WebApplication2.Middlewares
{
    public class CustomExceptionHandlingMiddelware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlingMiddelware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception)
            {

                var dbContext = context.RequestServices.GetService<AppDbContext>();

                //log table 
             //   dbContext.Products.Add("")
              //log yapacağız
            }
        }
    }
}
