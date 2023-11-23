using System.Text.Json;
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
            catch (Exception e)
            {

                var dbContext = context.RequestServices.GetService<AppDbContext>();


                var exceptionMessage= e.Message;
                var exceptionPath = context.Request.Path.ToString();
                //var exceptionTime = DateTime.Now.ToString();

                var guidID = new Random().Next(100, int.MaxValue - 1).ToString();

                dbContext.AppLogs.Add(new()
                {
                    Message = exceptionMessage+ $"|{guidID}",
                    Path = exceptionPath,
                    LogTime = DateTime.Now
                });
                 dbContext.SaveChanges();

                context.Response.StatusCode = 500;

                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize($"bir hata meydana geldi daha sonra tekrar deneyiniz   hata kodu {guidID}" ));



            }
        }
    }
}
