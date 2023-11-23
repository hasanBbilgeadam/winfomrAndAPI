using Microsoft.Extensions.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApplication2.Middlewares
{
    public class CustomMiddleware
    {

        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            // api/product/getalll
            if (context.Request.Path.ToString().ToLower().Contains("product"))
            {
                //api rate control



                //ip control => blackListIP table 
                Console.WriteLine(context.Connection.RemoteIpAddress.ToString());

                var result = context.Request.Headers.TryGetValue("izin", out StringValues value);

                if (result)
                {
                    if (value.ToString() == "admin")
                    {
                        Console.Write("erişim başarılı");
                    }
                    else
                    {
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = 403;
                        await context.Response.WriteAsync(JsonSerializer.Serialize("buraya erişim iznin yok"));
                        return;
                    }
                }
                else
                {
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync(JsonSerializer.Serialize("buraya erişim iznin yok"));
                    return;
                }

            }


            await _next(context);
        }
    }
}
