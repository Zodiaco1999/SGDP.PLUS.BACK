using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.Middleware;
using SGDP.PLUS.SEG;

var builder = WebApplication.CreateBuilder(args);
string SpecificOrigins = "specificOrigins";

var corsOrigins = builder.Configuration.GetSection("CorsOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(SpecificOrigins,
    builder =>
    {
        builder.WithOrigins(corsOrigins!).AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddHttpContextAccessor();
builder.Services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddSingleton<IContextAccessor, ContextAccessor>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAplicacionesServices(builder.Configuration);

var app = builder.Build();

app.UseCors(SpecificOrigins);
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseRouting();

app.Use(async (context, next) =>
{
    context.Request.EnableBuffering();
    await next();
});

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<CustomExceptionMiddleware>();

app.UseRequestLocalization();

app.Run();
