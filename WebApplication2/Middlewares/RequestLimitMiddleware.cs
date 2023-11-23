using System.Text.Json;
using WebApplication2.Context;

namespace WebApplication2.Middlewares
{
    public class RequestLimitMiddleware
    {

        private readonly RequestDelegate _next;

        public RequestLimitMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) 
        {
            
            //requestion header'da id isimli bir şey var mı


            var idControl = context.Request.Headers.TryGetValue("id", out var id);

            if (!idControl)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync(JsonSerializer.Serialize("user id değeri olmak zorunda"));
                return;
            }


            var dbContext = context.RequestServices.GetService<AppDbContext>();

            var user = dbContext.AppUsers.Where(x=>x.Id == int.Parse(id.ToString())).FirstOrDefault();

            if (user == null)
            {

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync(JsonSerializer.Serialize("böyle kullanıcı yok"));
                return;
            }

            

            if (user.Limit > 0)
            {
                user.Limit = --user.Limit;
                dbContext.SaveChanges();
                
               await  _next(context);
                
            }
            else
            {
                if (user.Limit == 0 && user.EndDate == null)
                {
                    user.EndDate = DateTime.Now.AddHours(1);
                    dbContext.SaveChanges();
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync(JsonSerializer.Serialize("çok fazla deneme yaptınız bir saat bekleyiniz ceza süresi "+DateTime.Now.ToString()));
                    return;
                }
                if (user.Limit== 0&& user.EndDate !=null) 
                {
                    if (user.EndDate.Value < DateTime.Now)
                    {
                        //ceza bitti

                        user.Limit = 100;
                        user.EndDate = null;
                        dbContext.SaveChanges();
                        await _next(context);
                    }

                    else
                    {
                        user.EndDate = DateTime.Now.AddHours(1);
                        dbContext.SaveChanges();
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = 403;
                        await context.Response.WriteAsync(JsonSerializer.Serialize("bekleme süreniz hala devam ediyor"));
                        return;
                    }
                }
            }




        
        }




      
    }
}
