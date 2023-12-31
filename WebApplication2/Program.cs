using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Filters;
using WebApplication2.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<GlobalExceptionFilter>();

builder.Services.AddControllers(o =>
{
    //o.Filters.AddService<GlobalExceptionFilter>();
});
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


//app.UseExceptionHandler()
app.UseMiddleware<CustomExceptionHandlingMiddelware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<RequestLimitMiddleware>();//bu genel izin
app.UseMiddleware<CustomMiddleware>();//product endpoint ile alakal�

app.MapControllers();




app.Run();
